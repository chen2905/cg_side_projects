USE [Columbus]
GO

/****** Object:  StoredProcedure [dbo].[syp_Hotel_Columbus_pmGeocodeWithScroll]    Script Date: 20/10/2020 11:17:31 AM ******/
DROP PROCEDURE [dbo].[syp_Hotel_Columbus_pmGeocodeWithScroll]
GO

/****** Object:  StoredProcedure [dbo].[syp_Hotel_Columbus_pmGeocodeWithScroll]    Script Date: 20/10/2020 11:17:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
-33.8688197 151.2092955
syp_Hotel_Columbus_pmGeocodeWithScroll '-33.8688197','151.2092955',10,'KM',1,5,''
syp_Hotel_Columbus_pmGeocodeWithScroll '-33.8688197','151.2092955',100000,'KM',1,10,'','star'

syp_Hotel_Columbus_pmGeocodeWithScroll '-33.8688197','151.2092955',100000,'KM',1,10,'','hotelname'

syp_Hotel_Columbus_pmGeocodeWithScroll '','',2,20


*/

CREATE PROCEDURE [dbo].[syp_Hotel_Columbus_pmGeocodeWithScroll]  (	
	@CentreLat varchar(15),
	@CentreLon varchar(15),
	@Radius int,
	@Measure  nvarchar(10), 
	@PageNumber int,
	@PageSize int,
	@SelectedStars  varchar(200)='',
	@Sort  varchar(200)=''
)

AS
BEGIN


declare @SelectStarsTable table (Star int)
while charindex(',',@SelectedStars) > 0
begin
 insert into @SelectStarsTable (Star) values(left(@SelectedStars,charindex(',',@SelectedStars)-1))
 set @SelectedStars = right(@SelectedStars,len(@SelectedStars)-charindex(',',@SelectedStars))
end
 insert into @SelectStarsTable (Star) values(@SelectedStars)

 -- syp_Hotel_Columbus_pmGeocodeWithScroll '-33.8688197','151.2092955',100000,'KM',2,10
 Declare @StartRow int
 Declare @EndRow int

 Set @StartRow = ((@PageNumber - 1) * @PageSize) + 1
 Set @EndRow = @PageNumber * @PageSize;
  DECLARE @Divisor AS INT
 DECLARE @orig geography = geography::Point(@CentreLat, @CentreLon, 4326);

 IF @Measure = 'KM' OR @Measure = 'K'
BEGIN
	SET @Divisor = 1000
END
ELSE
BEGIN
	IF @Measure = 'MI' OR @Measure = 'M'  
		SET @Divisor = 1609.344
	ELSE 
		SET @Divisor = 1
END
;

  SELECT  H.HotelID, H.Hotel AS HotelName, H.City, H.Stars, CAST(H.Stars AS int) AS intStars  ,H.HotelStatus,H.Rating,
  H.Allotment,H.xCountryID,H.RegionName, 
  CONVERT(DECIMAL(10,2),(@orig.STDistance(geography::Point(Latitude, Longitude, 4326)) /@Divisor))  AS DistanceFromCenter,
  Latitude AS Lat,
  Longitude AS lng,
  CASE 
 WHEN @Sort ='distance' THEN  ROW_NUMBER() OVER (ORDER BY (@orig.STDistance(geography::Point(Latitude, Longitude, 4326))) ASC) 
 WHEN @Sort ='star' THEN ROW_NUMBER() OVER (ORDER BY Stars  DESC,(@orig.STDistance(geography::Point(Latitude, Longitude, 4326))) ASC)    
 WHEN @Sort ='hotelname' THEN ROW_NUMBER() OVER (ORDER BY H.Hotel ASC,(@orig.STDistance(geography::Point(Latitude, Longitude, 4326))) ASC)  
 ELSE ROW_NUMBER() OVER (ORDER BY (@orig.STDistance(geography::Point(Latitude, Longitude, 4326))) ASC)  END
     AS ROWNUMBER
INTO #tmpHotel
  From vw_HotelSearch H
  INNER JOIN tblGeoCode GC ON GC.SrcType =  1 AND GC.xSrcID = H.HotelID AND GC.GeoCodeStatus = 0
  Where
  HotelStatus=0
  AND(@orig.STDistance(geography::Point(Latitude, Longitude, 4326)) /@Divisor) < (@Radius)
  AND  (
  (@SelectedStars ='')
  OR
  (
  @SelectedStars<>'' AND (CAST(H.Stars AS int) in ( SELECT Star from @SelectStarsTable))
	)
  )


	

 SELECT HotelID,
 HotelName,
 City,
 Stars,
 HotelStatus,
 Rating,
 Allotment,
 xCountryID,
 RegionName,
 DistanceFromCenter,
 Lat,
 Lng,
 ROWNUMBER AS HotelOrder,
 (SELECT COUNT(*) FROM #tmpHotel) AS TotalRows
 FROM #tmpHotel
 WHERE ROWNUMBER BETWEEN @StartRow AND @EndRow
 ORDER BY HotelOrder  ASC
DROP table  #tmpHotel

End


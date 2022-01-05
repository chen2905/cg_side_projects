using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HotelRepos
/// </summary>
public class HotelRepos :iHotelRepos
    {
    private  ISqlDataAccess _db;
    public HotelRepos()
        {
        //
        // TODO: Add constructor logic here
        //
      
        }

    List<Hotel> iHotelRepos.lstHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber, int iPageSize, string iSelectedStars, string iSort)
        {
        _db = Factory.CreateSqlDA();
        string SqlString = @"syp_Hotel_Columbus_pmGeocodeWithScroll 
                            @CentreLat,
                            @CentreLon,
                            @Radius,
	                        @Measure, 
                            @PageNumber,
                            @PageSize,
                            @SelectedStars,
                            @Sort
                            ";
        object param = new
            {
            CentreLat = iCentreLat,
            CentreLon = iCentreLon,
            Radius = iRadius,
            Measure = iMeasure,
            PageNumber = iPageNumber,
            PageSize = iPageSize,
            SelectedStars = iSelectedStars,
            Sort = iSort
            };
        List<Hotel> lstHotels = _db.LoadData<Hotel, dynamic>(SqlString, param);

        if (lstHotels.Count > 0)
            {
            foreach (Hotel hotel in lstHotels)
                {
                hotel.HotelImagePath = HotelImagePath(hotel.HotelID);
                }

          
            }

        return lstHotels;
        }




    private string HotelImagePath(int iHotelID)
        {
        string hotelImagePath = "";
        _db = Factory.CreateSqlDA();
        string SqlString = @"sdp_HotelImage_pmHotelID @HotelID";
        object param = new
            {
            HotelID = iHotelID
            };
        List<HotelImage> lstHotelImages = _db.LoadData<HotelImage, dynamic>(SqlString, param);

        if (lstHotelImages.Count > 0)
            {
            hotelImagePath = lstHotelImages[0].ImageCSecure;
            }


        return hotelImagePath;
        }

    }
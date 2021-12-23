using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Dapper;
/// <summary>
/// Summary description for ws_hotel
/// </summary>

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ws_hotel : System.Web.Services.WebService
    {

    [WebMethod]
    public void SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure,int iPageNumber, int iPageSize,string iSelectedStars, string iSort)
        {
        ISqlDataAccess _db = new SqlDataAccess();
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
            Radius =iRadius,
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

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(lstHotels));
            }


        }

    private string HotelImagePath(int iHotelID)
        {
        string hotelImagePath = "";
        ISqlDataAccess _db = new SqlDataAccess();
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



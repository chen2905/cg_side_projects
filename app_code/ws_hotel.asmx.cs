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
      

        iHotelRepos _hotel = Factory.CreateHotel();

        List<Hotel> lstHotels = _hotel.lstHotels(iCentreLat, iCentreLon, iRadius, iMeasure, iPageNumber, iPageSize, iSelectedStars, iSort);

        if (lstHotels.Count > 0)
            {
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(lstHotels));
            }


        }

   
    }



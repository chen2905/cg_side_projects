using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;


namespace web_api
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class HotelController : ApiController
    {

       
        [HttpGet]
       
        public List<Hotel> Get(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber,
                                    int iPageSize, string iSelectedStars, string iSort)
            {

            IHotelRepos _hotelRepos = new HotelRepos();

            if (iSelectedStars ==null)
                {
                iSelectedStars = ""; 
                }


            return _hotelRepos.SearchHotels(iCentreLat, iCentreLon, iRadius, iMeasure, iPageNumber,
                                     iPageSize, iSelectedStars, iSort);

            //return _hotelRepos.SearchHotels("-33.8688197", "151.2092955", 100, "km", 1,
            //                         10, "", "distance");
            }



        }
}

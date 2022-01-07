using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api
    {
    public class HotelRepos : IHotelRepos
        {
        public List<Hotel> SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber,
                                   int iPageSize, string iSelectedStars, string iSort)
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
                Radius = iRadius,
                Measure = iMeasure,
                PageNumber = iPageNumber,
                PageSize = iPageSize,
                SelectedStars = iSelectedStars,
                Sort = iSort
                };
            List<Hotel> lstHotels = _db.LoadData<Hotel, dynamic>(SqlString, param);

            lstHotels.ForEach(h => h.HotelImagePath = HotelImagePath(h.HotelID));

            // oTotalRows = 0;
            //if (lstHotels.Count > 0)
            //    {
            //    foreach (Hotel hotel in lstHotels)
            //        {
            //        hotel.HotelImagePath = HotelImagePath(hotel.HotelID);
            //        //oTotalRows = hotel.TotalRows;
            //        }


            //    }

            return lstHotels;
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
    }
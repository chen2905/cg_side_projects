using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace wcf_services
    {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
        {
        public List<Hotel> SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber, int iPageSize, string iSelectedStars, string iSort)
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

            if (lstHotels.Count > 0)
                {
                foreach (Hotel hotel in lstHotels)
                    {
                    hotel.HotelImagePath = HotelImagePath(hotel.HotelID);
                    }

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //Context.Response.Write(js.Serialize(lstHotels));
                }
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

        public CompositeType GetDataUsingDataContract(CompositeType composite)
            {
            if (composite == null)
                {
                throw new ArgumentNullException("composite");
                }
            if (composite.BoolValue)
                {
                composite.StringValue += "Suffix";
                }
            return composite;
            }
        }
    }

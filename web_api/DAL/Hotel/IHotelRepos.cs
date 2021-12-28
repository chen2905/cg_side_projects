using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_api
    {
    interface IHotelRepos
        {
        List<Hotel> SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber,
                                    int iPageSize, string iSelectedStars, string iSort);
        }
    }

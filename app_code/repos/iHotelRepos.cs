using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for iHotelRepos
/// </summary>
public interface iHotelRepos
    {
    List<Hotel> lstHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber, int iPageSize, string iSelectedStars, string iSort);
       
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Factory
/// </summary>
public static class Factory
    {
    public static ISqlDataAccess CreateSqlDA()
        {
        return new SqlDataAccess();

        }

    public static iHotelRepos CreateHotel()
        {
        return new HotelRepos();

        }
    }
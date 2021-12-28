
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace web_api
    {
    public static class Helper
        {
        public static SqlConnection DBConn()
            {
            string _connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return new SqlConnection(_connStr);
            }



        }


    }
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

public static class Helper
    {
    public static SqlConnection DBConn()
        {
        string _connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        return new SqlConnection(_connStr);
        }
}
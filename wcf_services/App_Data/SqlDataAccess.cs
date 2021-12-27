using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
public class SqlDataAccess : ISqlDataAccess
    {
    public List<T> LoadData<T, U>(string sql, U parameters)
        {

        using (SqlConnection connection = Helper.DBConn())
            {

            var data = connection.Query<T>(sql, parameters);

            return data.ToList();
            }
        }

    public T LoadSingleData<T, U>(string sql, U parameters)
        {
        using (var connection = Helper.DBConn())
            {
            var data = connection.Query<T>(sql, parameters);

            return data.FirstOrDefault();
            }
        }

    public int InsertData<U>(string sql, U parameters)
        {
        using (var connection = Helper.DBConn())
            {
            return connection.QuerySingle<int>(sql, parameters);

            }
        }

    public int UpdateData<U>(string sql, U parameters)
        {
        using (var connection = Helper.DBConn())
            {
            return connection.Execute(sql, parameters);

            }
        }


    }
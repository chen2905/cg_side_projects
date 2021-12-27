using System.Collections.Generic;
public interface ISqlDataAccess
    {
    List<T> LoadData<T, U>(string sql, U parameters);
    T LoadSingleData<T, U>(string sql, U parameters);
    int InsertData<U>(string sql, U parameters);

    int UpdateData<U>(string sql, U parameters);
    }
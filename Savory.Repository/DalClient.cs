using Savory.TitanService.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    public class DalClient
    {
        readonly SqlConnection sqlConn;

        public DalClient(SqlConnection sqlConn)
        {
            this.sqlConn = sqlConn;
        }

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, (List<SqlParameter>)null);
        }

        public int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            return ExecuteNonQuery(sql, parameters != null ? parameters.ToList() : null);
        }

        public int ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            var sqlCmd = new SqlCommand();

            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = sql;
            if (parameters != null && parameters.Count > 0)
            {
                sqlCmd.Parameters.AddRange(parameters.ToArray());
            }

            sqlConn.Open();

            return sqlCmd.ExecuteNonQuery();
        }
        #endregion


        #region ExecuteReader
        public T ExecuteReader<T>(string sql, Func<SqlDataReader, T> func)
        {
            return ExecuteReader(sql, (List<SqlParameter>)null, func);
        }

        public T ExecuteReader<T>(string sql, SqlParameter[] parameters, Func<SqlDataReader, T> func)
        {
            return ExecuteReader(sql, parameters != null ? parameters.ToList() : null, func);
        }

        public T ExecuteReader<T>(string sql, List<SqlParameter> parameters, Func<SqlDataReader, T> func)
        {
            var sqlCmd = new SqlCommand();

            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = sql;
            if (parameters != null && parameters.Count > 0)
            {
                sqlCmd.Parameters.AddRange(parameters.ToArray());
            }

            sqlConn.Open();

            var reader = sqlCmd.ExecuteReader();

            return func(reader);
        }
        #endregion
    }
}

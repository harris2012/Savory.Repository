using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Savory.Repository
{
    /// <summary>
    /// SqlConnectionProvider
    /// </summary>
    public static class SqlProvider
    {
        /// <summary>
        /// Gets an opened SqlConnection instance.
        /// </summary>
        /// <param name="connectioName">Name of the connection</param>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection(string connectioName)
        {
            var connString = ConfigurationManager.ConnectionStrings[connectioName].ConnectionString;

            SqlConnection sqlConn = new SqlConnection(connString);

            sqlConn.Open();

            return sqlConn;
        }

        /// <summary>
        /// Gets an SqlCommand instance from an opened SqlConnection instance for sp.
        /// </summary>
        /// <param name="storedProcedure">Name of a stored procedure.</param>
        /// <param name="sqlConn">An opened SqlConnection instance.</param>
        /// <returns></returns>
        public static SqlCommand GetSqlCommandForSp(string storedProcedure, SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = storedProcedure;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            return sqlCmd;
        }

        /// <summary>
        /// Gets an SqlCommand instance from an opened SqlConnection instance for text command.
        /// </summary>
        /// <param name="cmdText">Query or commands</param>
        /// <param name="sqlConn">An opened SqlConnection instance.</param>
        /// <returns></returns>
        public static SqlCommand GetSqlCommandForText(string cmdText, SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = cmdText;

            return sqlCmd;
        }
    }
}

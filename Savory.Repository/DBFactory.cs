using Savory.TitanService.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    public static class DBFactory
    {
        public static DalClient GetClient(string DBName)
        {
            var titanClient = new TitanServiceClient();

            var connString = titanClient.GetConnString(DBName);

            DalClient client = new DalClient(new SqlConnection(connString));

            return client;
        }
    }
}

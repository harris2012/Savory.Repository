using Savory.TitanService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    public static class ConnStringProvider
    {
        public static string GetConnString(string DBName)
        {
            TitanServiceClient titanClient = new TitanServiceClient();

            return titanClient.GetConnString(DBName);
        }
    }
}

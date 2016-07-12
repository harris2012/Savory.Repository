using Ranta.Utility;
using Savory.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    public class ConfigRepository
    {
        public static string GetConfigValue(string configName)
        {
            string configValue = string.Empty;

            var entityList = GetConfigEntityList();
            if (entityList != null && entityList.Count > 0)
            {
                var entity = entityList.FirstOrDefault(v => v.ConfigName.Equals(configName, StringComparison.OrdinalIgnoreCase));

                if (entity != null)
                {
                    configValue = entity.ConfigValue;
                }
            }

            return configValue;
        }

        public static List<ConfigEntity> GetConfigEntityList()
        {
            List<ConfigEntity> returnValue = RuntimeCache.GetDataWithAbsoluteExpiration("CacheKey_ConfigList", () =>
            {
                List<ConfigEntity> entityList = new List<ConfigEntity>();

                using (var sqlConn = SqlProvider.GetSqlConnection(SqlProvider.GetConnName()))
                {
                    var sqlCmd = SqlProvider.GetSqlCommandForSp(SpNameConst.Sp_GetConfigList, sqlConn);

                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var entity = new ConfigEntity();

                        entity.ConfigName = reader[ParamNameConst.ConfigName].ToString();
                        entity.ConfigValue = reader[ParamNameConst.ConfigValue].ToString();

                        entityList.Add(entity);
                    }
                }

                return entityList;
            }, 5);

            return returnValue;
        }
    }
}

using Ranta.Utility;
using Savory.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    public sealed class ConfigRepository
    {
        private const string DefaultConfigTableName = "Cfg_General";

        /// <summary>
        /// 配置表名称
        /// </summary>
        public string ConfigTableName { get; private set; }

        public ConfigRepository()
        {
            ConfigTableName = DefaultConfigTableName;
        }

        public ConfigRepository(string configTableName)
        {
            if (string.IsNullOrEmpty(configTableName))
            {
                throw new ArgumentNullException(nameof(configTableName));
            }

            ConfigTableName = configTableName;
        }

        public static ConfigRepository GetRepository(string configTableName)
        {
            return new ConfigRepository(configTableName);
        }

        public string GetConfigValue(string configName)
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

        public List<ConfigEntity> GetConfigEntityList()
        {
            List<ConfigEntity> returnValue = RuntimeCache.GetDataWithAbsoluteExpiration("CacheKey_ConfigList", () =>
            {
                List<ConfigEntity> entityList = new List<ConfigEntity>();

                string sql = string.Format(@"SELECT ConfigName, ConfigValue FROM {0} WHERE DataStatus = 1", ConfigTableName);

                using (var sqlConn = SqlProvider.GetSqlConnection(SqlProvider.GetConnName()))
                {
                    var sqlCmd = SqlProvider.GetSqlCommandForText(sql, sqlConn);

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

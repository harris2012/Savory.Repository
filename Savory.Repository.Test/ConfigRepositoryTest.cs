using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Savory.Repository.Test
{
    [TestClass]
    public class ConfigRepositoryTest
    {
        [TestMethod]
        public void TestGetConfigEntityList()
        {
            {
                var list = new ConfigRepository().GetConfigEntityList();

                Assert.IsNotNull(list);

                Assert.AreNotEqual(0, list.Count);
            }

            {
                var list = new ConfigRepository("Cfg_Qiniu").GetConfigEntityList();

                Assert.IsNotNull(list);

                Assert.AreNotEqual(0, list.Count);


            }

            {
                var list = new ConfigRepository("Cfg_UEditor").GetConfigEntityList();

                Assert.IsNotNull(list);

                Assert.AreNotEqual(0, list.Count);
            }
        }
    }
}
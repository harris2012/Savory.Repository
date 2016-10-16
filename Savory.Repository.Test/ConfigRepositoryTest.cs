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
                //Assert.AreEqual(1, list.Count);
            }

            {
                var list = new ConfigRepository(ConfigTableName.QiniuCofig).GetConfigEntityList();

                Assert.IsNotNull(list);

                Assert.AreNotEqual(0, list.Count);
                //Assert.AreEqual(7, list.Count);
            }

            {
                var list = ConfigRepository.GetRepository(ConfigTableName.UEditorConfig).GetConfigEntityList();

                Assert.IsNotNull(list);

                Assert.AreNotEqual(0, list.Count);
                //Assert.AreEqual(35, list.Count);
            }
        }
    }
}
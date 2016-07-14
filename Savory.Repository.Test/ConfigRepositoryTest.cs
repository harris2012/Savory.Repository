using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Savory.Repository.Test
{
    [TestClass]
    public class ConfigRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = ConfigRepository.GetConfigEntityList();

            Assert.IsNotNull(list);

            Assert.AreNotEqual(0, list.Count);
        }
    }
}

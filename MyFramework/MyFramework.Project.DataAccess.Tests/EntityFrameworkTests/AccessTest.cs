using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFramework.Project.DataAccess.Concrete.EntityFramework;

namespace MyFramework.Project.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class AccessTest
    {
        [TestMethod]
        public void Get_all_returns_product()
        {
            EfProductDal _dB = new EfProductDal();
            var result = _dB.GetAll().ToList();
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Get_all_returns_filtered_product()
        {
            EfProductDal _dB = new EfProductDal();
            var result = _dB.GetAll().Where(i=>i.Name=="Bilgisayar").FirstOrDefault();
            Assert.AreEqual(null, result);
        }
    }
}

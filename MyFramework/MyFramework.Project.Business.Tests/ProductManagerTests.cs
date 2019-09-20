using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyFramework.Project.Business.Concrete.Managers;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product { Price = 100, CategoryId = 2 });
        }
    }
}

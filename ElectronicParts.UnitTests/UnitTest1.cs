using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicParts.WebUI.Controllers;
using Moq;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Concrete;
using ElectronicParts.Domain.Entities;
using System.Linq;
using ElectronicParts.WebUI.Models;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace ElectronicParts.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Filter_ElectronicPart()
        {
            Mock<IElectronicPartRepository> mock = new Mock<IElectronicPartRepository>();
            mock.Setup(m => m.ElectronicParts).Returns(new ElectronicPart[] 
            {
                new ElectronicPart{ElectronicPartID=1,Category="Category1" },
                new ElectronicPart{ElectronicPartID=2,Category="Category1" },
                new ElectronicPart{ElectronicPartID=3,Category="Category2" },
                new ElectronicPart{ElectronicPartID=4,Category="Category2" }
            });

            ElectronicPartController controler = new ElectronicPartController(mock.Object);

            ElectronicPart[] result = ((ElectronicPartViewModel)controler.List("Category1",null).Model).EleParts.ToArray();

            Assert.AreEqual(result.Length,2);
            Assert.IsTrue(result[0].ElectronicPartID == 1 && result[0].Category == "Category1");
            Assert.IsTrue(result[1].ElectronicPartID == 2 && result[1].Category == "Category1");
        }
    
        [TestMethod]
        public void Can_Make_Categories()
        {
            Mock<IElectronicPartRepository> mock = new Mock<IElectronicPartRepository>();
            mock.Setup(m => m.ElectronicParts).Returns(new ElectronicPart[]
            {
                new ElectronicPart{ElectronicPartID = 1,Name = "Name1" ,Category= "Category1"},
                new ElectronicPart{ElectronicPartID = 2,Name = "Name2" ,Category= "Category2"},
                new ElectronicPart{ElectronicPartID = 3,Name = "Name3" ,Category= "Category3"}
            });

            NavigationController navigationController = new NavigationController(mock.Object);

            string[] result = ((IEnumerable<string>)navigationController.Menu().Model).ToArray();


            Assert.AreEqual(result[0], "Category1");
            Assert.AreEqual(result.Length, 3);
        }

        [TestMethod]
        public void Can_Filter_ElectronicPart_ByResistance()
        {
            Mock<IElectronicPartRepository> mock = new Mock<IElectronicPartRepository>();
            mock.Setup(m => m.ElectronicParts).Returns(new ElectronicPart[]
            {
                new ElectronicPart{ElectronicPartID=1,Value=10, Category="cat1" },
                new ElectronicPart{ElectronicPartID=2,Value=20, Category="cat1" },
                new ElectronicPart{ElectronicPartID=3,Value=30, Category="cat1"},
                new ElectronicPart{ElectronicPartID=4,Value=40, Category="cat1" }
            });

            ElectronicPartController electronicPartController = new ElectronicPartController(mock.Object);

            ElectronicPart[] result = ((ElectronicPartViewModel)electronicPartController.List("cat1", 10).Model).EleParts.ToArray();

            Assert.AreEqual(result.Length, 1);
        }
    }
}

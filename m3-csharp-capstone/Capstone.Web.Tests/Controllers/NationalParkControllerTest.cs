using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using Moq;
using Capstone.Web.Models;
using Capstone.Web.Controllers;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class NationalParkControllerTest
    {
        [TestMethod]
        public void ParkDetail_WhenCorrectParkCode_ExpectDetailInfo()
        {
            //New park
            NationalParkModel parkModel = new NationalParkModel();
            parkModel.ParkCode = "RMNP";

            //Mock the dal
            Mock<IParkDAL> mockDAL = new Mock<IParkDAL>();

            //Set up the mock object
            mockDAL.Setup(p => p.GetPark("RMNP")).Returns(parkModel);

            //Create the controller
            NationalParkController controller = new NationalParkController(mockDAL.Object);

            //Act
            var result = controller.Detail("RMNP");

            //Assert
            Assert.IsTrue(result is ViewResult);
            var view = result as ViewResult;
            Assert.AreEqual("Detail", view.ViewName);
            Assert.IsNotNull(view.Model);

            var nationalParkModel = view.Model as NationalParkModel;
            Assert.AreEqual("RMNP", nationalParkModel.ParkCode);
        }
    }
}

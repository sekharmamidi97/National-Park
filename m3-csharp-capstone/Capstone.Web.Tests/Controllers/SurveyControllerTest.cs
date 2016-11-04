using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Moq;
using Capstone.Web.Controllers;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class SurveyControllerTest
    {
        [TestMethod]
        public void ListAction_WhenSurveyCompleted_ExpectPost()
        {
            //Arrange
            var fakeComplete = new List<SurveyModel>()
            {
                new SurveyModel {ParkCode = "CVNP", EmailAddress = "faker@hotmail.com", PhysicalActivityLevel = "Sedentary", StateOfResidence = "Alabama", NumberOfVotes = 2 },
                new SurveyModel {ParkCode = "GTNP", EmailAddress = "meatman@yahoo.com", PhysicalActivityLevel = "Inactive", StateOfResidence = "Illinois", NumberOfVotes = 4 }
            };
            // Mock the dal
            Mock<ISurveyDAL> mockDal = new Mock<ISurveyDAL>();

            //Set up the mock object
            mockDal.Setup(s => s.GetAllSurveys()).Returns(fakeComplete);

            SurveyController controller = new SurveyController(mockDal.Object);

            //Act
            var result = controller.DisplaySurvey() as ViewResult;

            //Assert
            Assert.AreEqual("DisplaySurvey", result.ViewName);
            Assert.IsNotNull(result.Model);
        }

    }
}

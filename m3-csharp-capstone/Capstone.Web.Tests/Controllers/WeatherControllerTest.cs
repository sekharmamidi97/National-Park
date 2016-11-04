using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using Moq;
using Capstone.Web.Models;
using System.Collections.Generic;
using Capstone.Web.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTest
    {
        [TestMethod]
        public void ClickForecastLink_ReturnDetailedForecast()
        {
            //Arrange
            var fakeWeather = new List<ParkWeatherModel>()
            {
                new ParkWeatherModel {ParkCode = "RMNP", Day = 2, Forecast = "Sunny", High = 75, Low = 50, TemperatureType = "Fahrenheit (F)"},
                new ParkWeatherModel {ParkCode = "RMNP", Day = 6, Forecast = "Cloudy", High = 80, Low = 65, TemperatureType = "Celsius(C)" }
            };

            //Mock Session Object
            Mock<HttpSessionStateBase> mockSession = new Mock<HttpSessionStateBase>();

            //Mock Http Context Request for Controller
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();

            //When the Controller calls this.Session, it will get a mock session
            mockContext.Setup(s => s.Session).Returns(mockSession.Object);

            //Mock the dal
            Mock<IWeatherDAL> mockDAL = new Mock<IWeatherDAL>();

            //Set up the mock object
            mockDAL.Setup(w => w.GetAllWeather("RMNP")).Returns(fakeWeather);

            //Create the controller
            WeatherController controller = new WeatherController(mockDAL.Object);

            //Assign the context property on the controller to our mock context which uses our mock session
            controller.ControllerContext = new ControllerContext(mockContext.Object, new RouteData(), controller);
            
            //Act
            var result = controller.Forecast("RMNP");

            //Assert
            Assert.IsTrue(result is ViewResult);
            var view = result as ViewResult;
            Assert.AreEqual("Forecast", view.ViewName);
            Assert.IsNotNull(view.Model);

            var forecastEntry = view.Model as List<ParkWeatherModel>;
            Assert.AreEqual("RMNP", forecastEntry[0].ParkCode);
        }
    }
}

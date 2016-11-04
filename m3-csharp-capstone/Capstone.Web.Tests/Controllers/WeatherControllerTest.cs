using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using Moq;
using Capstone.Web.Models;
using System.Collections.Generic;
using Capstone.Web.Controllers;
using System.Web.Mvc;

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

            //Mock the dal
            Mock<IWeatherDAL> mockDAL = new Mock<IWeatherDAL>();

            //Set up the mock object
            mockDAL.Setup(w => w.GetAllWeather("RMNP")).Returns(fakeWeather);

            //Create the controller
            WeatherController controller = new WeatherController(mockDAL.Object);

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

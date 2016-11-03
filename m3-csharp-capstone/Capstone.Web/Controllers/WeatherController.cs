using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDAL;
        private const string Session_Temperature = "Fahrenheit (F)";

        public WeatherController(IWeatherDAL weatherDAL)
        {
            this.weatherDAL = weatherDAL;
        }

        
        public ActionResult Forecast(string parkCode)
        {
            
            List<ParkWeatherModel> model = weatherDAL.GetAllWeather(parkCode);
            foreach(var temperature in model)
            {
                temperature.TemperatureType = Convert.ToString(Session[Session_Temperature]);
            }
            return View("Forecast", model);
        }
        [HttpPost]
        public ActionResult TemperatureConversion(string temp, string parkCode)
        {
            Session[Session_Temperature] = temp;
            return RedirectToAction("Forecast", new { parkCode = parkCode });
        }
    }
}
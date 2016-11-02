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

        public WeatherController(IWeatherDAL weatherDAL)
        {
            this.weatherDAL = weatherDAL;
        }


        public ActionResult Forecast(string parkCode)
        {
            List<ParkWeatherModel> model = weatherDAL.GetAllWeather(parkCode);
            return View("Forecast", model);
        }
    }
}
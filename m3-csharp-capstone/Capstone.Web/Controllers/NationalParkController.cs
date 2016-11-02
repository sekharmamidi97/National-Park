using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Capstone.Web.Controllers
{
    public class NationalParkController : Controller
    {
        private IParkDAL parkDAL;

        public NationalParkController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        // GET: NationalPark
        public ActionResult Index()
        {
            List<NationalParkModel> list = parkDAL.GetAllParks();
            return View("Index", list);
        }
        public ActionResult Detail(string parkCode)
        {
            NationalParkModel model = parkDAL.GetPark(parkCode);
            return View("Detail", model);
        }
    }
}
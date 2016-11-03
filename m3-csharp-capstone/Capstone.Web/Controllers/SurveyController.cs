using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;

        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }
        // GET: Survey
        public ActionResult DisplaySurvey()
        {
            List<SurveyModel> model = surveyDAL.GetAllSurveys();
            
            return View("DisplaySurvey", model);
        }
        public ActionResult NewSurveyPost()
        {
            ViewBag.ParkName = parkName;
            return View("NewSurveyPost", new SurveyModel());
        }
        [HttpPost]
        public ActionResult NewSurveyPost(SurveyModel model)

        {
            if (ModelState.IsValid)
            {
                surveyDAL.SaveSurveys(model);
                return RedirectToAction("DisplaySurvey");
            }
            else
            {
                ViewBag.ParkName = parkName;
                return View("NewSurveyPost", model);
            }


        }

        private List<SelectListItem> parkName = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() {Text = "Everglades National Park", Value = "ENP" },
            new SelectListItem() {Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem() {Text = "Glacier National Park", Value = "GNP" },
            new SelectListItem() {Text = "Great Smoky Mountain National Park", Value = "GSMNP" },
            new SelectListItem() {Text = "Grand Teton National Park", Value = "GTNP" },
            new SelectListItem() {Text = "Mount Ranier National Park", Value = "MRNP" },
            new SelectListItem() {Text = "Rocky Mountain National Park", Value = "RMNP" },
            new SelectListItem() {Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem() {Text = "Yosemite National Park", Value = "YNP2" },

        };

    }
}


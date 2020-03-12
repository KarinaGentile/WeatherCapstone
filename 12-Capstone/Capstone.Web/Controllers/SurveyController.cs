using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDAO;

        public SurveyController(ISurveyDAO survey)
        {
            this.surveyDAO = survey;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Survey survey = new Survey();
            return View(survey);

        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            bool isSuccess = surveyDAO.SaveSurvey(survey);

            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Some required information was missing. Please try again.";
                return View(survey);
            }
            else if (!isSuccess)
            {
                TempData["Message"] = "I'm sorry. Please try resubmitting a survey.";
                return View(survey);
            }
            // post survey to database
            // then redirect

            TempData["Message"] = "Survey successfully submitted. Thanks!";
            return RedirectToAction("FavoriteParks");
        }

        public IActionResult FavoriteParks(IList<Park> GetParks)
        {
            List<Park> listOfParks = new List<Park>();
            surveyDAO.FindTopPark();

            return View();
        }
    }
}
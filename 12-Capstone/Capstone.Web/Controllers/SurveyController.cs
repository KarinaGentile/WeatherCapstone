using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Survey dummySurvey = new Survey();
            return View(dummySurvey);
        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Some required information was missing. Please try again.";
                return View(survey);
            }
            // post survey to database
            // then redirect
            TempData["Message"] = "Survey successfully submitted. Thanks!";
            return RedirectToAction("FavoriteParks");
        }

        public IActionResult FavoriteParks()
        {
            return View();
        }
    }
}
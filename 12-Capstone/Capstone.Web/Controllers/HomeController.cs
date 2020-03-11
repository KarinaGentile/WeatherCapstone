using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // get parks
            IList<Park> parks = new List<Park>();
            return View(parks);
        }

        public IActionResult Detail(string code)
        {
            // this will eventually grab the park detail based on the park code passed in
            Park dummyPark = new Park()
            {
                Name = "CVNP",
                Description = @"lorem ipsum ytgewlifahuefhw eufhwuagyefiuwfauewhfaiuzew efgywiahuehfwuhaeowf fehwufhau ffehwuifa fehwufiaejigjare",
                ParkCode = "CVNP",
                State = "OH",
                Acreage = 10,
                Elevation = 100,
                MilesOfTrail = 1.0M,
                NumberOfCampsites = 1000,
                Climate = "Ohio-y",
                YearFounded = 1776,
                AnnualVisitorCount = 10000,
                InspirationalQuote = "Never don't give up.",
                InspirationQuoteSource = "Anonymous",
                EntryFee = 0,
                NumberOfAnimalSpecies = 5
            };
            return View(dummyPark);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

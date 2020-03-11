using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        public IParkDAO parkDAO;
        public IWeatherDAO weatherDAO;

        public HomeController(IParkDAO park, IWeatherDAO weather)
        {
            this.parkDAO = park;
            this.weatherDAO = weather;
        }

        public IActionResult Index()
        {
            // get parks
            IList<Park> parks = new List<Park>();
            return View(parks);
        }

        public IActionResult Detail(string code)
        {
            // this will eventually grab the park detail based on the park code passed in
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

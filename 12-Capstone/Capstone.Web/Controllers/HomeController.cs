using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;

        public HomeController(IParkDAO park, IWeatherDAO weather)
        {
            this.parkDAO = park;
            this.weatherDAO = weather;
        }

        public IActionResult Index()
        {
            // get parks
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string code)
        {
            if (!HttpContext.Session.Keys.Contains("temp"))
            {
                HttpContext.Session.SetString("temp", "f");
            }

            TempData["temp"] = HttpContext.Session.GetString("temp");

            Park park = parkDAO.GetParkByParkCode(code);
            List<Weather> fiveDay = weatherDAO.GetForecast(code);

            DetailViewModel vm = new DetailViewModel();
            vm.FiveDay = fiveDay;
            vm.forecasts = new List<Forecast>();

            if (HttpContext.Session.GetString("temp") == "f")
            {
                vm.isFahrenheit = true;
            }
            else
            {
                vm.isFahrenheit = false;
            }

            vm.Park = park;
            return View(vm);

        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Detail(string code, string temp)
        {
            if (!HttpContext.Session.Keys.Contains("temp"))
            {
                HttpContext.Session.SetString("temp", "f");
            }

            if (temp != HttpContext.Session.GetString("temp"))
            {
                HttpContext.Session.SetString("temp", temp);
            }

            Park park = parkDAO.GetParkByParkCode(code);
            List<Weather> fiveDay = weatherDAO.GetForecast(code);

            DetailViewModel vm = new DetailViewModel();
            vm.FiveDay = fiveDay;
            vm.forecasts = new List<Forecast>();
            if (HttpContext.Session.GetString("temp") == "f")
            {
                vm.isFahrenheit = true;
            }
            else
            {
                vm.isFahrenheit = false;
            }

            vm.Park = park;
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}


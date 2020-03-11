using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int FiveDayForecast { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public string Forecast { get; set; }


        public int CelsiusConversion(decimal temp)
        {
            decimal tempInCelsius = ((temp - 32) * (decimal)(.56));
            return (int)tempInCelsius;
        }



    }
}





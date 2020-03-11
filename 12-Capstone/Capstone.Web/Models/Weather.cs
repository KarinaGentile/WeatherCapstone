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
        public decimal FiveDayForecastValue { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public string ForeCast { get; set; }

    }
}

using Capstone.Web.DAL;
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
        public int FiveDayForecastValue { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public string Forecast { get; set; }

        //private string _forecast;

        //public string Forecast
        //{
        //    get { return _forecast; }
        //    set 
        //    {
        //        if (value == "partly cloudy")
        //        {
        //            _forecast = "partlyCloudy";
        //        }
        //        _forecast = value; 
        //    }
        //}


        public string Recommendation()
        {
            string a = "";
            string b = "";
            string c = "";
            string d = "";

            if (Forecast == "snow")
            {
                a = "Pack snowshoes!";
            }
            else if (Forecast == "rain")
            {
                a = "Pack rain gear and wear waterproof shoes!";
            }
            else if (Forecast == "thunderstorms")
            {
                a = "Seek shelter and avoid hiking on exposed ridges!";
            }
            else if (Forecast == "sunny")
            {
                a = "Pack sunblock!";
            }
            else if (Forecast == "partly cloudy")
            {
                a = "Dress in layers!";
            }
            if (High > 75)
            {
                b = " Don't forget to bring an extra gallon of water!";
            }
            if (High - Low > 20)
            {
                c = " Be sure to wear breathable layers!";
            }
            if (Low < 20)
            {
                d = " Be careful! Exposure to frigid temperatures could be dangerous to your health!";
            }
            return a + b + c + d;
        }

    }
}






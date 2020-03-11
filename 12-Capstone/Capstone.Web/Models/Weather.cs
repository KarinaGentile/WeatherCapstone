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


        public int CelsiusConversion(decimal temp)
        {
            decimal tempInCelsius = ((temp - 32) * (decimal)(.56));
            return (int)tempInCelsius;
        }

        public class FiveDayForecast
        {
            internal IWeatherDAO dao;

            internal void GetFiveDay(IWeatherDAO dao, string id)
            {
                this.dao = dao;
                this.Id = id;
                fiveDayForecast = dao.GetForecast(id);         
            }


            List<Weather> fiveDayForecast;

            public string Id { get; set; }
            public string ParkName { get; set; }

            public bool IsFahrenheit { get; set; }

            public List<Weather> GetForecast(string id)
            {
                List<Weather> list = dao.GetForecast(id);
                return list;
            }

            public string GetParkName(string id)
            {
                string parkName = fiveDayForecast[0].ParkName;
                return parkName;
            }


            public int FiveDayForecastValue;
            public string GetDay()
            {
                if (FiveDayForecastValue == 1)
                {
                    return "Today";
                }
                else if (FiveDayForecastValue == 2)
                {
                    return DateTime.Today.AddDays(1).DayOfWeek.ToString();
                }
                else if (FiveDayForecastValue == 3)
                {
                    return DateTime.Today.AddDays(2).DayOfWeek.ToString();
                }
                else if (FiveDayForecastValue == 4)
                {
                    return DateTime.Today.AddDays(3).DayOfWeek.ToString();
                }
                else
                {
                    return DateTime.Today.AddDays(4).DayOfWeek.ToString();
                }


            }
        }
    }
}






using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public string Id { get; set; }
        public bool IsFahrenheit { get; set; }

            public IWeatherDAO dao;

            public void GetFiveDay(IWeatherDAO dao, string id)
            {
                this.dao = dao;
                this.Id = id;
                fiveDayForecast = dao.GetForecast(id);
            }

            List<Weather> fiveDayForecast;

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


using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {

        private string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetForecast(string parkCode)
        {
            List<Weather> forecast = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM WEATHER JOIN PARK ON park.parkCode = weather.parkCode WHERE park.parkCode = @parkcode", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather w = new Weather()
                        {
                            ParkName = Convert.ToString(reader["parkName"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToDecimal(reader["low"]),
                            High = Convert.ToDecimal(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"]),

                        };
                        forecast.Add(w);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return forecast;
        }

    }
}


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

                    SqlCommand cmd = new SqlCommand("SELECT * FROM WEATHER", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather w = new Weather()
                        {
                            Name = Convert.ToString(reader["parkName"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            State = Convert.ToString(reader["state"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                            EntryFee = Convert.ToInt32(reader["entryfee"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            Climate = Convert.ToString(reader["climate"]),
                            InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                            InspirationQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            MilesOfTrail = Convert.ToDecimal(reader["milesOfTrail"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"])


                        };
                        listOfParks.Add(p);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOfParks;
        }
    }
    }
}

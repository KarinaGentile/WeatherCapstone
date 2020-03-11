﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Park GetParkByParkCode(string parkCode)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //params

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        park = RowToPark(rdr);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return park;
        }

        public IList<Park> GetParks()
        {
            List<Park> listOfParks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PARK", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park p = this.RowToPark(reader);
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

        public Park RowToPark(SqlDataReader reader)
        {
            return new Park()
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
        }
    }
}

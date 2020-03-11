using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {

        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string SQL_InsertSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        public string SQL_FindTopPark = "SELECT TOP 1 parkName from park JOIN survey_result on park.parkCode = survey_result.parkCode GROUP BY park.parkName ORDER BY COUNT(*) DESC;";


        public string result;
        public string FindTopPark()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_FindTopPark, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey sur = new Survey();
                        sur.TopPark = Convert.ToString(reader["parkName"]);
                        result = sur.TopPark;
                    }

                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM SURVEY_RESULT", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Survey s = new Survey()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            EmailAddress = Convert.ToString(reader["email"]),
                            State = Convert.ToString(reader["state"]),
                            ActivityLevel = Convert.ToString(reader["activityLevel"]),

                        };
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}

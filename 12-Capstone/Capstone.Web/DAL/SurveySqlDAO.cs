﻿using Capstone.Web.Models;
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

        public string SQL_InsertSurvey = @"INSERT INTO survey_result
(parkCode, emailAddress, state, activityLevel)
VALUES
(@parkCode, @emailAddress, @state, @activityLevel);";
        public string SQL_FindTopPark = "SELECT parkName from park JOIN survey_result on park.parkCode = survey_result.parkCode WHERE surveyID > 0 GROUP BY park.parkName ORDER BY COUNT(*) DESC";

//        private string SQL_GetFavoriteParks = @"select count(*), p.parkCode, p.parkName, p.parkDescription from survey_result sr
//join park p on sr.parkCode = p.parkCode
//group by p.parkCode, p.parkName, p.parkDescription
//order by count(*) desc, p.parkName";


        public string result;
        //public string FindTopParks()
        //{
        //    IList<Park> parks = new List<Park>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string SQL = SQL_GetFavoriteParks;

        //            SqlCommand cmd = new SqlCommand(SQL, conn);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
                        
                        
        //            }

        //        }
        //        return result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string SQL = SQL_InsertSurvey;

                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.FavoriteParkSelection);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}

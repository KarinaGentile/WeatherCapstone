using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO: ISurveyDAO
    {

        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string SQL_InsertSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        public string SQL_FindTopPark = "SELECT top 1 parkName from park join survey_result on park.parkCode = survey_result.parkCode group by park.parkName order by count(*) desc;";

        public string FindTopPark()
        {
            throw new NotImplementedException();
        }

        public bool SaveSurvey(Survey newSurvey)
        {
            throw new NotImplementedException();
        }
    }
}

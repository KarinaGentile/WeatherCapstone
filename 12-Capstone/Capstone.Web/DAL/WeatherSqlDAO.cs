﻿using System;
using System.Collections.Generic;
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
    }
}

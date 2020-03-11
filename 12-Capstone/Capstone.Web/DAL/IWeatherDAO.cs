using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    interface IWeatherDAO
    {
        List<Weather> GetForecast(string parkCode);
    }
}

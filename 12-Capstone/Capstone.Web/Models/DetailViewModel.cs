﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set; }

        public Forecast Forecast { get; set; }

        public Weather Weather { get ; set; }

        public IList<Weather> FiveDay { get; set; }

        public IList<Forecast> forecasts { get; set; }

        public bool isFahrenheit { get; set; }
    }
}

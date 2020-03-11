using System;
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

        public decimal Low { get; set; }
        public decimal High { get; set; }
    }
}

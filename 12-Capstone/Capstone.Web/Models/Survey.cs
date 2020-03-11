using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required]
        //drop down
        public string State { get; set; }

        [Required]
        // drop down
        public string ActivityLevel { get; set; }

        [Required]
        // drop down
        public string FavoriteParkSelection { get; set; }

        public string TopPark { get; set; }

        public static List<SelectListItem> PhysicalActivityLevel
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Inactive", Value = "Inactive" },
                    new SelectListItem {Text = "Sedentary", Value = "Sedentary" },
                    new SelectListItem {Text = "Active", Value = "Active" },
                    new SelectListItem {Text = "Extremely Active", Value = "Extremely Active" }
                };
            }
        }
        public List<SelectListItem> FavoritePark
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Cuyahoga Valley National Park", Value = "CVNP" },
                    new SelectListItem {Text = "Everglades National Park", Value = "ENP" },
                    new SelectListItem {Text = "Grand Canyon National Park", Value = "GCNP" },
                    new SelectListItem {Text = "Glacier National Park", Value = "GNP" },
                    new SelectListItem {Text = "Great Smoky Mountains National Park", Value = "GSMNP" },
                    new SelectListItem {Text = "Grand Teton National Park", Value = "GTNP" },
                    new SelectListItem {Text = "Mount Rainier National Park", Value = "MRNP" },
                    new SelectListItem {Text = "Rocky Mountain National Park", Value = "RMNP" },
                    new SelectListItem {Text = "Yellowstone National Park", Value = "YNP" },
                    new SelectListItem {Text = "Yosemite National Park", Value = "YNP2" },

                };
            }
        }
    }
}


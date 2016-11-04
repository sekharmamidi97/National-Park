using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        [Required (ErrorMessage = "You must select a park name")]
        public string ParkCode { get; set; }

        [Required (ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required (ErrorMessage = "State of residence is required")]
        public string StateOfResidence { get; set; }

        [Required (ErrorMessage = "You are required to select a physical activity level")]
        public string PhysicalActivityLevel { get; set; }

        public int NumberOfVotes { get; set; }
        


        public Dictionary<string, string> parkName = new Dictionary<string, string>()
        {
            {
                "CVNP", "Cuyahoga Valley National Park"
            },
            {
                "ENP", "Everglades National Park"
            },
            {
                "GCNP", "Grand Canyon National Park"
            },
            {
                "GNP", "Glacier National Park"
            },
            {
                "GSMNP", "Great Smoky Mountain National Park"
            },
            {
                "GTNP", "Grand Teton National Park"
            },
            {
                "MRNP", "Mount Ranier National Park"
            },
            {
                "RMNP", "Rocky Mountain National Park"
            },
            {
                "YNP", "Yellowstone National Park"
            },
            {
                "YNP2", "Yosemite National Park"
            }
        };

        public Dictionary<string, int> voteCount = new Dictionary<string, int>()
        {
            {
                "CVNP", 0
            },
            {
                "ENP", 0
            },
            {
                "GCNP", 0
            },
            {
                "GNP", 0
            },
            {
                "GSMNP", 0
            },
            {
                "GTNP", 0
            },
            {
                "MRNP", 0
            },
            {
                "RMNP", 0
            },
            {
                "YNP", 0
            },
            {
                "YNP2", 0
            }
        };

        public void UpdateDictionary(string parkCode, int votes)
        {
            voteCount[parkCode] = votes;
        }

    }
}
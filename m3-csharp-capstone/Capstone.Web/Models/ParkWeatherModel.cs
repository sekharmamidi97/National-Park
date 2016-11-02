using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkWeatherModel
    {
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public Dictionary<string, string> outlook = new Dictionary<string, string>()
        {
            {
                "cloudy","Cloudy"
            },
            {
                "sunny", "Sunny"
            },
            {
                "partlyCloudy", "Partly Cloudy"
            },
            {
                "snow", "Snow"
            },
            {
                "rain", "Rain"
            },
            {
                "thunderstorms", "Thunderstorms"
            }
        };

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

    }
}
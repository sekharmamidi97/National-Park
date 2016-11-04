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
        public string TemperatureType { get; set; }

        public string Unit()
        {
            if(TemperatureType == "Celsius (C)")
            {
                return (char)176 + "C";
            }
            return (char)176 + "F";
        }

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

        public string WeatherGear()
        {
            string s = "";

            if (Forecast == "snow")
            {
                s = s + "Pack snow shoes. ";
            }
            if (Forecast == "rain")
            {
                s = s + "Pack rain gear, with waterproof shoes. ";
            }
            if (Forecast == "thunderstorms")
            {
                s = s + "Seek shelter, don't hike on exposed ridges. ";
            }
            if (Forecast == "sunny")
            {
                s = s + "Pack sun block. ";
            }
            if (High > 75)
            {
                s = s + "Bring an extra gallon of water. ";
            }
            if (High - Low > 20)
            {
                s = s + "Wear breathable layers. ";
            }
            if (Low < 20)
            {
                s = s + "Being exposed to frigid temperatures can be harmful. ";
            }

            return s;
        }

        public int CalculateCelsius(int temperature)
        {
            if (TemperatureType == "Celsius (C)")
            {
                return (int)((temperature - 32) / 1.8);
            }
            return temperature;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAL : IWeatherDAL
    {
        private readonly string ConnectionString;

        public WeatherSQLDAL(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public List<ParkWeatherModel> GetAllWeather(string parkCode)

        {
            List<ParkWeatherModel> weather = new List<ParkWeatherModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * From weather WHERE parkCode = @ParkCode ORDER BY fiveDayForecastValue ASC", conn);
                    cmd.Parameters.AddWithValue("@ParkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        weather.Add(new ParkWeatherModel()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Day = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"]),
                        });

                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return weather;
        }


    }
}
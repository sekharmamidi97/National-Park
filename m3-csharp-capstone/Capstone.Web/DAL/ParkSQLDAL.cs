using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAL : IParkDAL

    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

        public ParkSQLDAL(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public List<NationalParkModel> GetAllParks()
        {
            List<NationalParkModel> output = new List<NationalParkModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From park;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new NationalParkModel()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            Quote = Convert.ToString(reader["inspirationalQuote"]),
                            QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            EntryFee = Convert.ToDecimal(reader["entryFee"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                        });

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

        public NationalParkModel GetPark(string parkCode)
        {
            NationalParkModel npm = new NationalParkModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From park WHERE parkCode = @ParkCode;", conn);
                    cmd.Parameters.AddWithValue("@ParkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        npm.ParkCode = Convert.ToString(reader["parkCode"]);
                        npm.ParkName = Convert.ToString(reader["parkName"]);
                        npm.State = Convert.ToString(reader["state"]);
                        npm.Acreage = Convert.ToInt32(reader["acreage"]);
                        npm.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        npm.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        npm.NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                        npm.Climate = Convert.ToString(reader["climate"]);
                        npm.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        npm.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        npm.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        npm.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        npm.Description = Convert.ToString(reader["parkDescription"]);
                        npm.EntryFee = Convert.ToDecimal(reader["entryFee"]);
                        npm.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return npm;

        }
    }
}

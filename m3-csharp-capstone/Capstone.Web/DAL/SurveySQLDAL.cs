using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAL : ISurveyDAL
    {
        private readonly string ConnectionString;

        public SurveySQLDAL(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;

        }

        public List<SurveyModel> GetAllSurveys()
        {
            SurveyModel model = new SurveyModel();

            List<SurveyModel> output = new List<SurveyModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select parkCode, COUNT (parkCode) AS 'NumberofVotes' From survey_result GROUP BY parkCode ORDER BY NumberofVotes DESC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new SurveyModel()
                        {
                            NumberOfVotes = Convert.ToInt32(reader["NumberofVotes"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            //EmailAddress = Convert.ToString(reader["emailAddress"]),
                            //StateOfResidence = Convert.ToString(reader["state"]),
                            //PhysicalActivityLevel = Convert.ToString(reader["activityLevel"]),

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

        public bool SaveSurveys(SurveyModel newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into survey_result Values (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.StateOfResidence);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.PhysicalActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
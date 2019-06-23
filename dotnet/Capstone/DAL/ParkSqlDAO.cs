using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.IO;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;
        
        /// <summary>
        /// Making the connection
        /// </summary>
        /// <param name="dbConnectionString"></param>
        public ParkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;            
        }

       
        /// <summary>
        /// To choose a park
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <returns></returns>

        public Park ListInfo(string menuChoice)
        {
            Park ChosenPark = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"select * from park where name = @park;", conn);
                    cmd.Parameters.AddWithValue("@park", menuChoice);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        ChosenPark = ReaderToPark(reader);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error getting park info");
                Console.WriteLine(ex.Message);
                throw;
            }
            return ChosenPark;
        }
        private Park ReaderToPark(SqlDataReader reader)
        {
            Park OutputPark = new Park();
            OutputPark.Id = Convert.ToInt32(reader["park_id"]);
            OutputPark.Name = Convert.ToString(reader["name"]);
            OutputPark.Location = Convert.ToString(reader["location"]);
            OutputPark.EstablishedDate = Convert.ToDateTime(reader["establish_date"]);
            OutputPark.Area = Convert.ToInt32(reader["area"]);
            OutputPark.Visitors = Convert.ToInt32(reader["visitors"]);
            OutputPark.Description = Convert.ToString(reader["description"]);
            return OutputPark;
        }
    }
}

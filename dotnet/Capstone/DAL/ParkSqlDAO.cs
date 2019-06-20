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
        public string menuChoice = "";
        
        public ParkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> ParkList()
        {
            //this is here because of the interface.  not sure if it's needed yet.
        }
            
        public Park ListInfo()
        {
            Park ChosenPark = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"select * from where name = {menuChoice} park;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                    }

                }
            }
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

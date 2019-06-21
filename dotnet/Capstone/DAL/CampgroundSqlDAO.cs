using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public string menuChoiceCampground = "";

        //public IList<Campground> CampgroundList();
        //{
            //List<Campground> Campgrounds = new List<Campground>();
            //return Campgrounds;
        //}

        public List<Campground> CampgroundListInfo(string chosenPark)
        {
            List<Campground> Campgrounds = new List<Campground>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string commandText = ($"select * from campground join park on park.park_id = campground.park_id where park.name = @customer_choice;");
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("@customer_choice", chosenPark);
                    command.CommandText = commandText;
                    command.Connection = connection;
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground container = new Campground();
                        container = ReaderToCampGround(reader);
                        Campgrounds.Add (container);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting campground info");
                Console.WriteLine(ex.Message);
                throw;
            }
            return Campgrounds;


        }
        private Campground ReaderToCampGround(SqlDataReader reader)
        {
            Campground OutputCampground = new Campground();
            OutputCampground.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            OutputCampground.ParkId = Convert.ToInt32(reader["park_id"]);
            OutputCampground.Name = Convert.ToString(reader["name"]);
            OutputCampground.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
            OutputCampground.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
            OutputCampground.Fee = Convert.ToInt32(reader["daily_fee"]);
            
            return OutputCampground;
        }
    }
}

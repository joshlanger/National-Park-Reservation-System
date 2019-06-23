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
                        string month = container.OpenFrom;
                        month = MonthWriter(month);
                        container.OpenFrom = month;
                        month = container.OpenTo;
                        month = MonthWriter(month);
                        container.OpenTo = month;
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
            OutputCampground.OpenFrom = Convert.ToString(reader["open_from_mm"]);//these were changed from toint32 to tostring
            OutputCampground.OpenTo = Convert.ToString(reader["open_to_mm"]);//
            OutputCampground.Fee = Convert.ToInt32(reader["daily_fee"]);
            
            return OutputCampground;
        }
        private string MonthWriter(string month)
        {
            switch(month)
            {
                case "1":
                    month = "January";
                    return month;

                case "2":
                    month = "February";
                    return month;

                case "3":
                    month = "March";
                    return month;

                case "4":
                    month = "April";
                    return month;

                case "5":
                    month = "May";
                    return month;

                case "6":
                    month = "June";
                    return month;

                case "7":
                    month = "July";
                    return month;

                case "8":
                    month = "August";
                    return month;

                case "9":
                    month = "September";
                    return month;

                case "10":
                    month = "October";
                    return month;

                case "11":
                    month = "November";
                    return month;

                case "12":
                    month = "December";
                    return month;

                default:
                    return month;
            }

            
        }
    }
}

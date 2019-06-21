using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public string reservationCampground = "";
        public string reservationName = "";

        public IList<Reservation> ReservationTime(int campgroundNumber, DateTimeOffset arrival, DateTimeOffset departure)
        {
            List<Reservation> AvailableCampgrounds = new List<Reservation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string commandText = ($"select * from campground join park on park_id = campground_id where park = @customer_choice;");
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("@customer_choice", chosenPark);
                    command.CommandText = commandText;
                    command.Connection = connection;
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting campground info");
                Console.WriteLine(ex.Message);
                throw;
            }

        }



        public IList<Reservation> ReservationSiteAndName(int siteNumber, string reservationName)
        {
            throw new NotImplementedException();
        }

        public IList<Site> ListSites()
        {
            throw new NotImplementedException();
        }

        public Site ListSiteInfo(string menuChoiceSite)
        {
            throw new NotImplementedException();
        }
    }
}
}

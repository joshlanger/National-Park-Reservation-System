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

        public IList<Site> ReservationTime(int campgroundNumber, double lengthOfStay, DateTimeOffset arrival, DateTimeOffset departure)
        {
            List<Site> AvailableCampgrounds = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string commandText = "select campground.*,site.* from campground join site on campground.campground_id = site.campground_id where site.site_id not in(select site_id from reservation where '2019-06-15' <= to_date and '2019-06-18' >= from_date);";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    //command.Parameters.AddWithValue("@customer_choice", chosenPark);
                    command.CommandText = commandText;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Site container = new Site();
                        container = ReaderToSite(reader);
                        AvailableCampgrounds.Add(container); 
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting campground info");
                Console.WriteLine(ex.Message);
                throw;
            }
            return AvailableCampgrounds;
        }
        private Site ReaderToSite(SqlDataReader reader)
        {
            Site OutputSite = new Site();
            //OutputSite.SiteId = Convert.ToInt32("site_id");
            //OutputSite.CampgroundId = Convert.ToInt32("campground_id");
            OutputSite.SiteNumber = Convert.ToInt32("site_number");
            OutputSite.MaxOccupancy = Convert.ToInt32("max_occupancy");
            OutputSite.Accessible = Convert.ToInt32("accessible");
            OutputSite.MaxRvLength = Convert.ToInt32("max_rv_length");
            OutputSite.Utilities = Convert.ToInt32("utilities");
            OutputSite.NightlyRate = Convert.ToDecimal("daily_fee");

            return OutputSite;

        }
    }
}


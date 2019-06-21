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
                    string commandText = "select campground.*,site.* from campground join site on campground.campground_id = site.campground_id where site.site_id not in(select site_id from reservation where '2019-06-15' <= to_date and '2019-06-18' >= from_date);";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    //command.Parameters.AddWithValue("@customer_choice", chosenPark);
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
            return AvailableCampgrounds;
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


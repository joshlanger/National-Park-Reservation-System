﻿using Capstone.Models;
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


        public List<Site> ReservationTime(int campgroundNumber, double lengthOfStay, DateTimeOffset arrival, DateTimeOffset departure)
        {
            List<Site> AvailableCampgrounds = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string commandText = "select top 5 site_number, max_occupancy, accessible, max_rv_length, utilities, (daily_fee * @lengthofstay) as daily_fee  from campground join site on campground.campground_id = site.campground_id where site.site_id not in(select @site from reservation where @from_date <= to_date and @to_date >= from_date);";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("@site", campgroundNumber);
                    command.Parameters.AddWithValue("@to_date", departure);
                    command.Parameters.AddWithValue("@from_date", arrival);
                    command.Parameters.AddWithValue("@lengthofstay", lengthOfStay);
                    command.CommandText = commandText;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Site container = new Site();
                        container = ReaderToSite(reader);
                        string siteProperty = container.Accessible;
                        container.Accessible = ConvertBool(siteProperty);
                        if(container.MaxRvLength == "0")
                        {
                            container.MaxRvLength = "N/A";
                        }
                        siteProperty = container.Utilities;
                        container.Utilities = ConvertBool(siteProperty);
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
            OutputSite.SiteNumber = Convert.ToInt32(reader["site_number"]);
            OutputSite.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            OutputSite.Accessible = Convert.ToString(reader["accessible"]);
            OutputSite.MaxRvLength = Convert.ToString(reader["max_rv_length"]);
            OutputSite.Utilities = Convert.ToString(reader["utilities"]);
            OutputSite.NightlyRate = Convert.ToDecimal(reader["daily_fee"]);

            return OutputSite;

        }
        public string ConvertBool (string siteProperty)
        {
            if (siteProperty == "False")
            {
                siteProperty = "No";
            }
            else
            {
                siteProperty = "Yes";
            }
            return siteProperty;
        }
    }
}


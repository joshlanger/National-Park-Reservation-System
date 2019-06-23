using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {

        private string connectionString;

        public ReservationSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int MakeReservation(Reservation CustomerInfo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into reservation values (@siteId, @reservationName, @arrival, @departure, @createdate); select scope_identity();", connection);
                    command.Parameters.AddWithValue("@siteId", CustomerInfo.SiteId);
                    command.Parameters.AddWithValue("@reservationName", CustomerInfo.ReservationName);
                    command.Parameters.AddWithValue("@arrival", CustomerInfo.Arrival);
                    command.Parameters.AddWithValue("@departure", CustomerInfo.Departure);
                    command.Parameters.AddWithValue("@createdate", CustomerInfo.CreateDate);

                    int reservationID = Convert.ToInt32(command.ExecuteScalar());
                    return reservationID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred making your reservation.");
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}

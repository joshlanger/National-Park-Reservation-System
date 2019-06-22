using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class TestsBaseClass
    {
        protected string ConnectionString = (@"Server =.\SQLEXPRESS; Database = npcampground; Trusted_Connection = True;");
        protected int CampgroundId { get; set; }
        protected int SiteId { get; set; }
        protected int ParkId { get; set; }
        private TransactionScope transaction;

        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string deleteText = "delete from campground; delete from site; delete from park;";
                SqlCommand command = new SqlCommand(deleteText, connection);
                command.ExecuteNonQuery();

                string cmdText = $"insert into campground values ({ParkId}; 'Bates Camp Site',1, 12, 125); select scope_identity();";
                command = new SqlCommand(cmdText, connection);
                CampgroundId = Convert.ToInt32(command.ExecuteScalar());

                cmdText = $"insert into site values({CampgroundId},1, 50, 0, 0, 0);select scope_identity();";
                command = new SqlCommand(cmdText, connection);
                SiteId = Convert.ToInt32(command.ExecuteScalar());

                cmdText = "insert into park values('Yellowstone','Montana', 34720, 3411024, 'This is a test description for Yellowstone'); select scope_identity();";
                command = new SqlCommand(cmdText, connection);
                ParkId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Roll back the transaction
            transaction.Dispose();
        }
    }
    
}

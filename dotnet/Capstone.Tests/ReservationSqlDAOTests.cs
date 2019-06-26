using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSqlDAOTest : CapstoneDAOTests
    {
        private ReservationSqlDAO dao {get; set;}

        [TestMethod]
        public void MakeReservationReturnsCorrectIDTest()
        {
            DateTime Arrival = new DateTime(2019, 07, 20);
            DateTime Departure = new DateTime(2019, 07, 23);
            string createTime = DateTime.Now.ToString();
            Reservation TestReservation = new Reservation();
            TestReservation.SiteId = SiteId;
            TestReservation.ReservationName = "Jane Doe";
            TestReservation.Arrival = Arrival;
            TestReservation.Departure = Departure;
            TestReservation.CreateDate = createTime;
            dao = new ReservationSqlDAO(ConnectionString);
            int idNumber = dao.MakeReservation(TestReservation);
            Assert.AreEqual((ReservationId + 1), idNumber);
        }
    }
}

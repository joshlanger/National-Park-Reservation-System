using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]

    public class SiteTests : TestsBaseClass
    {
        private SiteSqlDAO dao { get; set; }


        [TestMethod]

        public void GetAllReservations()
        {
            dao = new SiteSqlDAO(ConnectionString);
            IList<Site> getReservation = dao.ReservationTime(...);
            Assert.AreEqual(2, getReservation);
        }
    }
}

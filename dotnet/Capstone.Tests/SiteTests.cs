using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]

    public class SiteTests : TestsBaseClass
    {
        private SiteSqlDAO dao { get; set; }

        [TestMethod]

        public void SiteNumber()
        {
            dao = new SiteSqlDAO(ConnectionString);
            IList<Site> site = dao.ReservationTime(1, 4, Convert.ToDateTime("2019-06-27"), Convert.ToDateTime("2019-06-30"));
            Assert.AreEqual(1, site[0].SiteNumber);
        }
        [TestMethod]

        public void TotalFeeForReservationIsCorrectTest()
        {
            dao = new SiteSqlDAO(ConnectionString);
            IList<Site> site = dao.ReservationTime(1, 4, Convert.ToDateTime("2019-06-27"), Convert.ToDateTime("2019-06-30"));
            Assert.AreEqual(500, site[0].NightlyRate);
        }

    }
}

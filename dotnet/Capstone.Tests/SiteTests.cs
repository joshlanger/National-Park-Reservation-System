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

        public void GetSites()
        {
            dao = new SiteSqlDAO(ConnectionString);
            IList<Site> site = dao.ReservationTime(1, 4, Convert.ToDateTime(06-27-2019), Convert.ToDateTime(06-30-2019));
            Assert.AreEqual(ReservationId, 0);
        }

    }
}

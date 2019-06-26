using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundSqlDAOTests : CapstoneDAOTests
    {
        private CampgroundSqlDAO dao { get; set; }

        [TestMethod]

        public void GetAllCampgrounds()
        {
            dao = new CampgroundSqlDAO(ConnectionString);
            List<Campground> getCampgrounds = dao.CampgroundListInfo("Yellowstone");
            Assert.AreEqual("Bates Camp Site", getCampgrounds[0].Name);
            Assert.AreEqual("January", getCampgrounds[0].OpenFrom);
            Assert.AreEqual("December", getCampgrounds[0].OpenTo);
            Assert.AreEqual(125, getCampgrounds[0].Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetAllCampgroundsFailsBecauseOutOfBounds()
        {
            dao = new CampgroundSqlDAO(ConnectionString);
            List<Campground> getCampgrounds = dao.CampgroundListInfo("Yellowstone");
            Assert.AreEqual(null, getCampgrounds[1].Name);
        }
        
    }
}

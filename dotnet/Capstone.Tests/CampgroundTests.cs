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
    public class CampgroundTests : TestsBaseClass
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
<<<<<<< HEAD

=======
>>>>>>> f4202d8e9d802b591965a69e728c838e709a7b5c
        
    }
}

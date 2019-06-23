using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkTests : TestsBaseClass
    {
        private ParkSqlDAO dao { get; set; }
        

        [TestMethod]

        public void ChoosePark()
        {
            string menuChoice = "Acadia";
            dao = new ParkSqlDAO(ConnectionString);
<<<<<<< HEAD
            IList<Park> getParks = dao.ListInfo(menuChoice);
            Assert.AreEqual(2, getParks);
=======
            Park getParks = dao.ListInfo("Yellowstone");
            Assert.AreEqual("Yellowstone", getParks.Name);
        }

        [TestMethod]
        public void GetSpecificPark()
        {
            dao = new ParkSqlDAO(ConnectionString);
            Park getParks = dao.ListInfo($"{ParkId}");
            Assert.AreEqual(getParks.Id, 0);
        }

        [TestMethod]
        public void GetParkLocation()
        {
            dao = new ParkSqlDAO(ConnectionString);
            Park getParks = dao.ListInfo("Montana");
            Assert.AreEqual(getParks.Location, null);
>>>>>>> cf43f28d96ac35a37263cb25545da5d202d30ff7
        }

    }
}

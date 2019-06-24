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
            dao = new ParkSqlDAO(ConnectionString);
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
<<<<<<< HEAD

=======
>>>>>>> f4202d8e9d802b591965a69e728c838e709a7b5c
        }

    }
}

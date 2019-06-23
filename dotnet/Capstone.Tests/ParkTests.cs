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

        public void GetAllCampgrounds()
        {
            string menuChoice = "Acadia";
            dao = new ParkSqlDAO(ConnectionString);
            IList<Park> getParks = dao.ListInfo(menuChoice);
            Assert.AreEqual(2, getParks);
        }
        

        
    }
}

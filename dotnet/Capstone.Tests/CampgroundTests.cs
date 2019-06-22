using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    class CampgroundTests : TestsBaseClass
    {
        [TestMethod]

        public void GetAllCampgrounds()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            IList<Campground> getCampgrounds = dao.CampgroundListInfo("Bates Camp Site");
            Assert.AreEqual(1, getCampgrounds);
        }
    }
}

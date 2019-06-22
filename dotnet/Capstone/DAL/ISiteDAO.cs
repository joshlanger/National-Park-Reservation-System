using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        //IList<Site> ListSites();

        //Site ListSiteInfo(string menuChoiceSite);

        List<Site> ReservationTime(int campgroundNumber, double lengthOfStay, DateTimeOffset arrival, DateTimeOffset departure);
    }
}

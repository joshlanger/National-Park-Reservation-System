using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        IList<Site> ReservationTime(int campgroundNumber, DateTime arrival, DateTime depature);

        //Site ListSiteInfo(string menuChoiceSite);
    }
}

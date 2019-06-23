using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        List<Site> ReservationTime(int campgroundNumber, double lengthOfStay, DateTimeOffset arrival, DateTimeOffset departure);
    }
}

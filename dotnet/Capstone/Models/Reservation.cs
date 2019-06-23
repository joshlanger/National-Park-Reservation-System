using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Models
{
    public class Reservation
    {  
        public int SiteId { get; set; }
        public string ReservationName { get; set; }
        public DateTime  Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string CreateDate { get; set;}
        
    }
}

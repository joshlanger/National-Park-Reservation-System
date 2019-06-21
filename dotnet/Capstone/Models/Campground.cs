using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground 
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public decimal Fee { get; set; }

        public override string ToString()
        {
            return CampgroundId.ToString().PadRight(5)  + Name.PadRight(20) + OpenFrom.ToString().PadRight(10) + OpenTo.ToString().PadRight(10) + Fee.ToString("C2").PadRight(6);
        }
    }
}

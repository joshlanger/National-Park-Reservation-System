using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Models
{
    public class Site
    {
        //public int SiteId { get; set; }
        //public int CampgroundId { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public int Accessible { get; set; }
        public int MaxRvLength { get; set; }
        public int Utilities { get; set; }
        public decimal NightlyRate { get; set; }
        

        //public override string ToString()
        //{
        //    return SiteNumber.ToString().PadRight(5) + MaxOccupancy.ToString().PadRight(5) + Accessible.ToString().PadRight(10) + MaxRvLength.ToString().PadRight(10) + Utilities.ToString().PadRight(10) + NightlyRate.ToString("C2").PadRight(5);
        //}
        //SiteId.ToString().PadRight(5) + CampgroundId.ToString().PadRight(5) + 
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ztb.Entities.PostgresTables
{
    public class DriverStandingPsql
    {
        public int driver_standing_Id { get; set; }
        public int race_Id { get; set; }
        public int driver_Id { get; set; }
        public string driver_standing_points { get; set; }
        public string driver_standing_position { get; set; }
        public string driver_standing_position_Text { get; set; }
        public string driver_standing_wins { get; set; }
    }
}
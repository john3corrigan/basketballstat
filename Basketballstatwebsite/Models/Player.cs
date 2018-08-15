using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketballstatwebsite.Models
{
    public class Player
    {
      
            public int PlayerID { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public DateTime birthdate { get; set; }
            public decimal height { get; set; }
            public int TeamID { get; set; }
            public string TeamName { get; set; }
        
    }
}
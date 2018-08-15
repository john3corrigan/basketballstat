using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class playerDAO
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

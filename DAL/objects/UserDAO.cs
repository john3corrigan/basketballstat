using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class UserDAO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string username { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string role { get; set; }  
      
    }
}

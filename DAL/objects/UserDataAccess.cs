using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.objects;
using System.Data.SqlClient;
using System.Data;

namespace DAL.objects
{
    public class UserDataAccess
    {
        //reference our app config file and create a connectiuon string for our sql connection
        static string connectionstring = ConfigurationManager.ConnectionStrings["basketballDB"].ConnectionString;
        public UserDAO loginuser = new UserDAO();

       

        



    }
}

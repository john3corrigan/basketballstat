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
using utilitylogger;






namespace DAL
{
    public class PlayerDataAccess
    {

        //reference our app config file and create a connectiuon string for our sql connection
        static string connectionstring = ConfigurationManager.ConnectionStrings["basketballDB"].ConnectionString;



        //method used to delete a player
        public bool DeletePlayer(int playerTodelete)
        {
            bool success = false;
            try
            {
                //this is creating a connection to the databse
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the databse 
                    using (SqlCommand _command = new SqlCommand("sp_DeletePlayer", _connection))
                    {
                        //this specifies what type of command is being used 
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values will be passed to the command
                        _command.Parameters.AddWithValue("@PlayerID", playerTodelete);
                        //here is where the cinnection is opened
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();
                    }

                }


            }
            catch (Exception _error)
            {
                //Instatiate a new errorlog and name it log 
                ErrorLogger log = new ErrorLogger();
                //Call the log error method from errorlogger and pass it error value 
                log.LogError(_error);


            }

            //if (success == true)
            //{
            //    Console.WriteLine("You have successfully deleted a player.");
            //    Console.ReadLine();
            //}
            return success;

        }
        //cretae a method that will get all my players and place them in a 
        //list named _playerList
        public List<playerDAO> GetAllPlayers()
        {
            //creating a list variable named player list
            List<playerDAO> _playerlist = new List<playerDAO>();
            try
            {
                //establishing the connetion for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //establisheing the command to pass to the database
                    //and definning the command
                    using (SqlCommand _command = new SqlCommand("sp_ReadPlayer", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        //connect to the databse
                        _connection.Open();
                        //open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //loop through the dataset or command 
                            //and write each element to the _playerToList
                            //using the player object class
                            while (_reader.Read())
                            {
                                playerDAO _playerToList = new playerDAO();
                                _playerToList.PlayerID = _reader.GetInt32(0);
                                _playerToList.Firstname = _reader.GetString(1);
                                _playerToList.Lastname = _reader.GetString(2);
                                _playerToList.height = _reader.GetDecimal(3);
                                _playerToList.birthdate = _reader.GetDateTime(4);
                                _playerToList.TeamName = _reader.GetString(5);
                                _playerlist.Add(_playerToList);

                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                //instantiate the errologger class
                ErrorLogger logger = new ErrorLogger();
                //call the logger method and pass it value
                logger.LogError(error);

            }

            return _playerlist;
        }

        public void CreatePlayer()
        {
            using (SqlConnection _connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand _command = new SqlCommand("sp_createPlayer", _connection))
                {
                    playerDAO _playerTocreate = new playerDAO();
                    _command.CommandType = CommandType.StoredProcedure;
                    //connect to the databse
                    _connection.Open();
                    _command.Parameters.AddWithValue("@Firstname", _playerTocreate.Firstname);
                    _command.Parameters.AddWithValue("@Lastname", _playerTocreate.Lastname);
                    _command.Parameters.AddWithValue("@Birthdate", _playerTocreate.birthdate);
                    _command.Parameters.AddWithValue("@height", _playerTocreate.height);
                    _command.Parameters.AddWithValue("@TeamID", _playerTocreate.TeamID);
                    //here is where the cinnection is opened

                    //this executes the command
                    _command.ExecuteNonQuery();
                    _connection.Close();



                }


            }

        }
    }
}


    


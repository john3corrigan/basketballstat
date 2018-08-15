using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basketballstat.objects;


namespace basketballstat
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //create a new instance of the player data access 
           
            PlayerDataAccess data = new PlayerDataAccess();

            //communcitae with our end user 
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("View Playerss (V)?");
            Console.WriteLine("Delete a player form the database (D)?");
             
            string choice = Console.ReadLine().ToUpper();
            //enter the swicth case which will decide the method to call 
            //based on the value of choice
            switch (choice)
            {
                case "V":
                    //calling the player class placing it in a list 
                    //crating a new instacnce of the player class in a list
                    List<player> PlayerToView = new List<player>();
                    //call the view all players method and add 
                    //value to the player to view list
                   PlayerToView = data.GetAllPlayers();
                    //loop through the PlayerToView list and write out all the values
                    foreach (player singleplayer in PlayerToView)
                    {
                        //Console.WriteLine("{0:MM/dd/yyyy}", singleplayer.birthdate);
                        Console.WriteLine(singleplayer.PlayerID + " " + singleplayer.Lastname + " " + singleplayer.Firstname
                            + " " + singleplayer.height + " " + singleplayer.birthdate.ToString("MM/dd/yyyy") +  " " + singleplayer.TeamName);
                    }
                    Console.ReadLine();
                    break;
                    //this will run when the user inputs D into the choice variable
                case "D":
                    //prompt user for input
                    Console.WriteLine("Enter the ID of the player you would like to delete");
                    //converting users inpout to an integer
                    int deletechoice = Convert.ToInt32(Console.ReadLine());
                    //calling the player class and creaiting 
                    //an new instance of player class
                    player deleteplayer = new player();
                    //place the value of deletchoice into the player class
                    deleteplayer.PlayerID = deletechoice;
                    //call the delete player method from playerdataaccess 
                    //pass the player class named delete player to the method
                   bool check = data.DeletePlayer(deleteplayer);
                    if (check == true)
                    {
                        Console.WriteLine("You have successfully deleted a player form the database.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your delete failed.");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("You have entered an incorrect value try entering V or D");
                    Console.ReadLine();
                    break;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.objects;


namespace Basketballstatwebsite.Models
{
    public class Mapper
    {
        //mapper used to get all the data from the data access 
        //player for the playerview mode 
        //from the playerdao object 
        //use this mapoper in the HttpGET player controller action
        public List<Player> Map(List<playerDAO> _PlayerListToMap)
        {
            List<Player> _PlayerListToReturn = new List<Player>();
            foreach (playerDAO _PlayerToMap in _PlayerListToMap)
            {
                Player _PlayerToView = new Player();
                _PlayerToView.PlayerID = _PlayerToMap.PlayerID;
                _PlayerToView.Firstname = _PlayerToMap.Firstname;
                _PlayerToView.Lastname = _PlayerToMap.Lastname;
                _PlayerToView.height = _PlayerToMap.height;
                _PlayerToView.birthdate = _PlayerToMap.birthdate;
                _PlayerToView.TeamName = _PlayerToMap.TeamName;
                _PlayerListToReturn.Add(_PlayerToView);

            }
            return _PlayerListToReturn;

        }

        public playerDAO Map(Player _Playertodata)
        {
            playerDAO _PlayerD = new playerDAO();
            _PlayerD.Firstname = _Playertodata.Firstname;
            _PlayerD.Lastname = _Playertodata.Lastname;
            _PlayerD.height = _Playertodata.height;
            _PlayerD.TeamID = _Playertodata.TeamID;
            _PlayerD.birthdate = _Playertodata.birthdate;
            return _PlayerD;
            
        }
    


    }
}
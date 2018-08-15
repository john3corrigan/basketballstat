using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Basketballstatwebsite.Models;
using DAL;


namespace Basketballstatwebsite.Controllers
{
    public class PlayerController : Controller
    {
        //instatntiate the mapper so that I can use it throughout the controller
        static Mapper _mapper = new Mapper();
        //instatntiate the player data access class from the data access layer so 
        //I can use it trhoughout the controller
        static PlayerDataAccess _PlayerDataAccess = new PlayerDataAccess();

        // GET: Player for view 
        [HttpGet]

        public ActionResult ViewPlayers()
        {
            //instatiate the model and mname it _ViewModel
            PlayerViewModel _ViewModel = new PlayerViewModel();
            //mapp the viewmodel to the data access layer by passing the data access 
            //object to the map method
            _ViewModel.PlayerList = _mapper.Map(_PlayerDataAccess.GetAllPlayers());
            //load the viwewmodel into the view
            return View(_ViewModel);
        }
       //GET:get my delete "view" run the action for my delete "view" 
        public ActionResult Delete(int PlayerID)
        {
            
            Player _singleplayer = new Player();
            //call the method form the data access layer and pass the ID from the model to the method
            _PlayerDataAccess.DeletePlayer(PlayerID);
            return RedirectToAction("ViewPlayers");


        }
        // GET: Create view
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        // GET: AddPlayer  view
      
        [HttpPost]
        public ActionResult Create(Player Create)
        {
            Player _Create = new Player();
            _PlayerDataAccess.CreatePlayer();
            return View();
        }


        // GET: my Update view
        [HttpGet]
        public ActionResult Update()
        {
            return View("Update");
        }
        // GET: my Update view
        [HttpGet]
        public ActionResult View()
        {
            return View();
        }

    }
}
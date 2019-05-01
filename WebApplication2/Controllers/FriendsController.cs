using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class FriendsController : Controller
    {
        private readonly FriendsServiece FriendsServiece; 
        public FriendsController(FriendsServiece friendsService)
        {
            this.FriendsServiece = friendsService;
        }
        public IActionResult Index()
        {
            
            return View(FriendsServiece.GetAllFrinds());
        }

        public IActionResult SearchFriend(string Name)
        {

            var users = FriendsServiece.SearchFreinds(Name) ;
            
            return View(users);
        }


        public JsonResult SearchFriendAutoComplete(string Name)
        {

            return Json(FriendsServiece.SearchFreinds(Name));
        }

       

       public IActionResult AddFriend(string id , string partial  , string name  )
        {
            FriendsServiece.AddFriend(id);


            return PartialView(partial, FriendsServiece.SearchFreinds(name));     
        }

        public IActionResult AcceptRequest(string Id , string partial  , string name)
        {

            FriendsServiece.AcceptRequest(Id); 
            return PartialView( partial, FriendsServiece.SearchFreinds(name));
        }
        public IActionResult  DeleteFriend(string id , string partial  , string name )
        {
            FriendsServiece.DeleteFriend(id);
            
            return PartialView( partial, FriendsServiece.SearchFreinds(name));
        }


        public IActionResult RemoveRequest (string id, string partial, string name)
        {
            FriendsServiece.RemoveRequest(id);

            return PartialView(partial, FriendsServiece.SearchFreinds(name));
        }
    }
}
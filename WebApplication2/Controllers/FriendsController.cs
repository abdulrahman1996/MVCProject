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


        [HttpPost]
        public IActionResult AddFriend(string id , string partial  , string name  )
        {
            FriendsServiece.AddFriend(id);
            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);


            return PartialView(partial, FriendsServiece.SearchFreinds(name));     
        }



       public IActionResult AddFriend(string id , string partial    )
        {
            FriendsServiece.AddFriend(id);
            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);


            return PartialView(partial, FriendsServiece.GetUser(id));
        }


        [HttpPost]
        public IActionResult AcceptRequest(string Id , string partial  , string name)
        {
            ViewBag.friendState = FriendsServiece.GetFriendShipState(Id);

            FriendsServiece.AcceptRequest(Id); 
            return PartialView( partial, FriendsServiece.SearchFreinds(name));
        }

        public IActionResult AcceptRequest(string Id , string partial  )
        {
            ViewBag.friendState = FriendsServiece.GetFriendShipState(Id);

            FriendsServiece.AcceptRequest(Id);

            return PartialView(partial, FriendsServiece.GetUser(Id));
        }

        [HttpPost]
        public IActionResult  DeleteFriend(string id , string partial  , string name )
        {
            FriendsServiece.DeleteFriend(id);
            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);
            return PartialView( partial, FriendsServiece.SearchFreinds(name));
        }

        public IActionResult  DeleteFriend(string id , string partial   )
        {
            FriendsServiece.DeleteFriend(id);
            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);
            return PartialView(partial, FriendsServiece.GetUser(id));

        }

        [HttpPost]
        public IActionResult RemoveRequest (string id, string partial, string name)
        {
            FriendsServiece.RemoveRequest(id);
            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);

            return PartialView(partial, FriendsServiece.SearchFreinds(name));
        }
        
        public IActionResult RemoveRequest (string id, string partial)
        {
            FriendsServiece.RemoveRequest(id);

            ViewBag.friendState = FriendsServiece.GetFriendShipState(id);

            return PartialView(partial, FriendsServiece.GetUser(id));
        }
    }
}
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
            return View();
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

        public void SendRequest(string Id)
        {

        }

        public void DeleteRequest(string Id)
        {

        }

        public void AcceptRequest(string Id)
        {

        }
        public void DeleteFriend()
        {

        }
    }
}
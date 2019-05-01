using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ProfileService service;
        private readonly UserManager<ApplicationUser>user;
        private readonly IHostingEnvironment hosting;
        private readonly UserHomeService userHomeService;

        public ProfileController(ProfileService s, UserManager<ApplicationUser> u,IHostingEnvironment h, UserHomeService userHome)
        {
            userHomeService = userHome;
            service = s;
            user = u;
            hosting = h;
        }
        public IActionResult Index()
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;

            var res = service.GetAllUserPosts(user.GetUserAsync(HttpContext.User).Result.Id);
            ViewBag.posts = res;
            ViewBag.CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserUserName = userHomeService.GetUserName(CurrentUserID);

            ViewBag.user = user.GetUserAsync(HttpContext.User).Result;
            ViewBag.img= user.GetUserAsync(HttpContext.User).Result;

            return View();
        }
        public IActionResult getinfo()
        {
           // ViewBag.user = user.GetUserAsync(HttpContext.User).Result;
            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }

        public IActionResult Edit(string id)
        {
            // ViewBag.iD = id;
            //user.GetUserAsync(HttpContext.User).Result

            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUser applicationUser)
        {

            service.EditAsync(applicationUser);
            
            return PartialView("getinfo", applicationUser);
        }
       // profile/Id
        //[Route("/profile/{id}")]
        //public IActionResult GetProfile(string id)
        //{

        //    var res = service.GetAllUserPosts(user.GetUserAsync(HttpContext.User).Result.Id);
        //    ViewBag.posts = res;
        //    ViewBag.CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
        //    ViewBag.CurrentUserUserName = userHomeService.GetUserName(id);

        //    ViewBag.user = user.GetUserAsync(HttpContext.User).Result;
        //    ViewBag.img = user.GetUserAsync(HttpContext.User).Result;

        //    return View("Index");
        //}
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult GetAll(string UserID= "eb071205-0e4f-49d4-95e5-b943bd2c309e")
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;

            ViewBag.CurrentUserID = CurrentUserID;
            return PartialView(service.GetAllUserPosts(UserID));
        }

        [HttpPost]
        public IActionResult AddPost(string Content)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            Post post = new Post()
            {
                Content = Content,
                UserID = user.GetUserAsync(HttpContext.User).Result.Id,
                Timestamp = DateTime.Now,
                Deleted = false
            };

            userHomeService.AddUserPost(post);
            return PartialView("GetAll", service.GetAllUserPosts(CurrentUserID));
        }

        [HttpPost]
        public IActionResult IncrementLikes(int postId, string userid)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;

            userHomeService.IncrementLikes(postId, userid);
            return PartialView("GetAll", service.GetAllUserPosts(CurrentUserID));
        }

        public IActionResult AddComment(string content, int postId, string userid)
        {
            //string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = userid;
            userHomeService.AddComment(content, postId, userid);

            return PartialView("GetAll", service.GetAllUserPosts(userid));

        }

        public IActionResult GetAllLikes(int postId)
        {
            return PartialView(userHomeService.GetAllLikes(postId));

        }


        public IActionResult DeletePost(int postid)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            userHomeService.DeletePost(postid);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));
        }

        public IActionResult DeleteComment(int commentid, string userid)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = userid;

            userHomeService.DeleteComment(commentid);
            return PartialView("GetAll", service .GetAllUserPosts(CurrentUserID));
        }
        [HttpGet]
        public IActionResult EditPost(int postId)
        {
            Post post = userHomeService.EditPost(postId);
            return PartialView(post);
        }
        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            userHomeService.EditPost(post);
            return PartialView("GetAll", service.GetAllUserPosts(CurrentUserID));

        }

        [HttpGet]
        public IActionResult EditComment(int commentId)
        {
            Comment comment = userHomeService.EditComment(commentId);
            return PartialView(comment);
        }
        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            string CurrentUserID = user.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;
            userHomeService.EditComment(comment);
            return PartialView("GetAll", service.GetAllUserPosts(CurrentUserID));

        }

    }
}

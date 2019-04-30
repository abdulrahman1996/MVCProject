using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly UserHomeService userHomeService;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        
        public UserHomeController(UserHomeService userHome, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> SignInManager)
        {
            userHomeService = userHome;
            UserManager = usermanager;
            signInManager = SignInManager;

        }
        public IActionResult GetOnlyUserPosts(string userId)
        {
           // userId=
            ViewBag.CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            return PartialView("GetAll", userHomeService.GetOnlyUserPosts(userId));
        }

        public  IActionResult Index()
        {
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;

            var res = userHomeService.GetAllPosts(UserManager.GetUserAsync(HttpContext.User).Result.Id);
            ViewBag.posts = res;
            ViewBag.CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserUserName = userHomeService.GetUserName(CurrentUserID);


            return View();
        }

        public IActionResult GetAll()
        {

            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;

            ViewBag.CurrentUserID = CurrentUserID;
            return PartialView(userHomeService.GetAllPosts(CurrentUserID));
        }
        public IActionResult AddPost()
        {
            return PartialView();
        }
       
        [HttpPost]
        public IActionResult AddPost(string Content)
        {
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            Post post = new Post()
            {
                Content = Content,
                UserID = UserManager.GetUserAsync(HttpContext.User).Result.Id,
                Timestamp = DateTime.Now,
                Deleted=false
            };

            userHomeService.AddUserPost(post);
            return PartialView("GetAll",userHomeService.GetAllPosts(CurrentUserID));
        }
        
        //change current userid to userid
        [HttpPost]
        public IActionResult IncrementLikes(int postId,string userid)
        {
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;

            userHomeService.IncrementLikes(postId, userid);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));
        }
        
        public IActionResult AddComment(string content,int postId,string userid)
        {
            //string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = userid;
            userHomeService.AddComment(content, postId, userid);

            return PartialView("GetAll", userHomeService.GetAllPosts(userid));

        }

        public IActionResult GetAllLikes(int postId)
        {
            return PartialView(userHomeService.GetAllLikes(postId));

        }


        public IActionResult DeletePost(int postid)
        {
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            userHomeService.DeletePost(postid);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));
        }

        public IActionResult DeleteComment(int commentid, string userid)
        {
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = userid;

            userHomeService.DeleteComment(commentid);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));
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
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;

            userHomeService.EditPost(post);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));

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
            string CurrentUserID = UserManager.GetUserAsync(HttpContext.User).Result.Id;
            ViewBag.CurrentUserID = CurrentUserID;
            userHomeService.EditComment(comment);
            return PartialView("GetAll", userHomeService.GetAllPosts(CurrentUserID));

        }
    }
}
﻿using System;
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
        
        public IActionResult Index()
        {
            var res = userHomeService.GetAllPosts();
            ViewBag.posts = res;
            return View();
        }

        public IActionResult GetAll()
        {
            return PartialView(userHomeService.GetAllPosts());
        }
        public IActionResult AddPost()
        {
            return PartialView();
        }
       
        [HttpPost]
        public IActionResult AddPost(string Content)
        {
            Post post = new Post()
            {
                Content = Content,
                UserID = UserManager.GetUserAsync(HttpContext.User).Result.Id,
                Timestamp = DateTime.Now,
                Deleted=false
            };

            userHomeService.AddUserPost(post);
            return PartialView("GetAll",userHomeService.GetAllPosts());
        }
        
        [HttpPost]
        public IActionResult IncrementLikes(int postId,string userid)
        {
             userHomeService.IncrementLikes(postId, userid);
            return PartialView("GetAll", userHomeService.GetAllPosts());
        }
        
        public IActionResult AddComment(string content,int postId,string userid)
        {
            userHomeService.AddComment(content, postId, userid);
            return PartialView("GetAll", userHomeService.GetAllPosts());

        }

        public IActionResult GetAllLikes(int postId)
        {
            return PartialView(userHomeService.GetAllLikes(postId));

        }


        public IActionResult DeletePost(int postid)
        {
            userHomeService.DeletePost(postid);
            return PartialView("GetAll", userHomeService.GetAllPosts());
        }

        public IActionResult DeleteComment(int commentid)
        {
            userHomeService.DeleteComment(commentid);
            return PartialView("GetAll", userHomeService.GetAllPosts());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    //for admin only
    public class UserMangmentController : Controller
    {
        private readonly UserMangmentService UserService;
        private readonly UserManager<ApplicationUser> UserManager;
        // private ApplicationDbContext db;
        public UserMangmentController(UserMangmentService service, UserManager<ApplicationUser> usermanager)
        {
            UserService = service;
            UserManager = usermanager;
        }
        public IActionResult Index()
        {
            //var res = db.Roles.ToList();
            ViewBag.AllRoles = UserService.GetAll();
            return View(UserService.GetAll());
        }
        public IActionResult GetAll()
        {

            // ViewBag.AllRoles = res;
            // ViewBag.AllRoles = new SelectList(UserService.GetAllRoles(), "Id", "Name");

            return PartialView(UserService.GetAll());
        }
        [HttpPost]
        public IActionResult SearchByUsername(string username)
        {
            var res = UserService.SearchByUsername(username);

            return PartialView("GetAll", UserService.SearchByUsername(username));
        }
        [HttpPost]
        public IActionResult blockUser(string userID)
        {
            UserService.BlockUser(userID);
            return PartialView("GetAll", UserService.GetAll());
        }
        [HttpPost]
        public IActionResult Delete(string userID)
        {
            UserService.DeleteUser(userID);
            return PartialView("GetAll", UserService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser User, string Password)
        {
            //UserService.HashPassword(User,Password);
            //User.PasswordHash = hashedPassword;
            //UserService.CreateUser(User);
            User.UserName = User.Email;
            var res=await UserManager.CreateAsync(User,Password);
            return RedirectToAction("Index");
        }


    }
}
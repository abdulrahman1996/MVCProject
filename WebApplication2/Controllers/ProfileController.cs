using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService service;
        private readonly UserManager<ApplicationUser> user;

        public ProfileController(ProfileService s , UserManager<ApplicationUser>u)
        {
            service = s;
            user = u;
        }
        public IActionResult Index()
        {
           
            return View(user.GetUserAsync(HttpContext.User).Result);
        }
        public IActionResult getinfo()
        {
           
            return PartialView (user.GetUserAsync(HttpContext.User).Result);
        }

        public IActionResult Edit(string id)
        {
            //user.GetUserAsync(HttpContext.User).Result
            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUser applicationUser)
        {

            service.EditRoleAsync(applicationUser, user.GetUserAsync(HttpContext.User).Result);

            return PartialView("getinfo", user.GetUserAsync(HttpContext.User).Result);
        }

    }
}
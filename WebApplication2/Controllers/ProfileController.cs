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
    }
}
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
        private  ProfileService service { get; }
        private readonly UserManager<ApplicationUser> UserManager;

        public ProfileController(ProfileService s,UserManager<ApplicationUser> manager)
        {
            service = s;
            UserManager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ImageDiv()
        {
            return PartialView();
        }
    }
}
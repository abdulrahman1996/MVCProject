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
        public ProfileController(ProfileService s, UserManager<ApplicationUser> u,IHostingEnvironment h)
        {
            service = s;
            user = u;
            hosting = h;
        }
        public IActionResult Index()
        {
     
            return View(user.GetUserAsync(HttpContext.User).Result);
        }
    }
}
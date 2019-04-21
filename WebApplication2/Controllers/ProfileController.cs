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
      
        public IActionResult Index()
        {
         
            return View(user.GetUserAsync(HttpContext.User).Result);
        }
        public IActionResult ImageDiv()
        {
            return PartialView();
        }
    }
}
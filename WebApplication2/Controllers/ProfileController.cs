using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProfileController : Controller
    {
        private  ProfileService service { get; }
        public ProfileController(ProfileService s)
        {
            service = s;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
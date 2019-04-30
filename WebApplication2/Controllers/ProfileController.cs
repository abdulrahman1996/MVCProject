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

        [HttpGet]
        public IActionResult ImageDiv(/*IFormFile file*/)
        {

            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }
        [HttpPost]
        public IActionResult Imagesave()
        {
            var file = Request.Form.Files["imageUploadForm"];
            var fileName = Path.GetFileName(file.FileName);
            var pathImage = Path.Combine("images", fileName);
            var path = Path.Combine(hosting.WebRootPath, "images", fileName);
            file.CopyTo(new FileStream(path, FileMode.Create));
            ApplicationUser u = user.GetUserAsync(HttpContext.User).Result;
            u.ImagePath = pathImage;
            user.UpdateAsync(u);
            return PartialView("ImageDiv");
        }
    }
}
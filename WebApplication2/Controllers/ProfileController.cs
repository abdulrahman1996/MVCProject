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
        private readonly FriendsServiece friendsServiece;
        public ProfileController(ProfileService s, UserManager<ApplicationUser> u,IHostingEnvironment h  , FriendsServiece f)
        {
            service = s;
            friendsServiece = f;
            user = u;
            hosting = h;
        }
        public bool CurrUser = true;
        public IActionResult Index()
        {

            ViewBag.friendes = friendsServiece.GetAllFrinds();
            ViewBag.user = user.GetUserAsync(HttpContext.User).Result;
            ViewBag.CurrUser = CurrUser;

            return View(user.GetUserAsync(HttpContext.User).Result);

        }
        public IActionResult getinfo()
        {
            ViewBag.user = user.GetUserAsync(HttpContext.User).Result;

            ViewBag.CurrUser = CurrUser;

            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }

        public IActionResult Edit(string id)
        {
            // ViewBag.iD = id;
            //user.GetUserAsync(HttpContext.User).Result
            return PartialView(user.GetUserAsync(HttpContext.User).Result);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUser applicationUser)
        {

            service.EditAsync(applicationUser);

            return PartialView("getinfo", applicationUser);
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
            service.EditPhotoAsync(u);
            return PartialView("ImageDiv", user.GetUserAsync(HttpContext.User).Result);
        }
        //profile/Id
        //  [Route("/profile/{id}")]

        public IActionResult GetProfile(string id)
        {
            CurrUser = false;
            ViewBag.CurrUser = CurrUser;

            return View("Index");

        }

    }
}

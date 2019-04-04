using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminSettingController : Controller
    {

        private UserManager<ApplicationUser> UserManager;
       

        public AdminSettingController(UserManager<ApplicationUser> _userManager  )
        {
            UserManager = _userManager;
       

        }
        public async Task< IActionResult> Index()
        {
            var user =  await UserManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string UserName , string Email)
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            user.Email = Email;
            user.UserName = UserName;
            await UserManager.UpdateAsync(user);

            return PartialView("Edit", user);

        }
        // post and get 
        public void ChangePassword()
        {
            // confirm

        }
    }
}
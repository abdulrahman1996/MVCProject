using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class AdminSettingController : Controller
    {


        private AdminSettingService service { get; }

        public AdminSettingController(AdminSettingService _service)
        {
            service = _service;
        }
        public async Task< IActionResult> Index()
        {
            var user = await service.GetUser();
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string UserName , string Email)
        {
           
            return PartialView("Edit", await service.EditUserAsync(Email, UserName));
 
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string OldPassword , string NewPassword)
        {

            var result =  await service.ChangePasswordAsync(OldPassword, NewPassword);

            
            if (result.Succeeded)
            {
                TempData["updated"] = "Your Password Successfully Updated!";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code.ToString(), error.Description);
                }
            }

            return View();
        }

    }
}
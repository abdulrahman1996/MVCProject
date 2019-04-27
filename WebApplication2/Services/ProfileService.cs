using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ProfileService
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> UserManager;

        public HttpContext HttpContext { get; set; }
        public ProfileService(ApplicationDbContext d , UserManager<ApplicationUser> _userManager, IHttpContextAccessor httpContext)
        {
            db = d; 
            UserManager = _userManager;
            HttpContext = httpContext.HttpContext;

        }
        //public  GetCurrentUSer(ApplicationUser user)
        //{
        //    return;
        //}
    }
}

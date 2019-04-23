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
        public ProfileService(ApplicationDbContext d)
        {
            db = d;
        }
        public void EditRoleAsync(ApplicationUser u, ApplicationUser um)
        {
            if (u != null)
            {
               
                ApplicationUser applicationUser = db.Users.FirstOrDefault(r => r.Id == um.Id);
                applicationUser.UserName = u.UserName;
                applicationUser.PhoneNumber = u.PhoneNumber;
                applicationUser.Gender = u.Gender;
                applicationUser.City = u.City;
                applicationUser.Country = u.Country;
                db.SaveChanges();

            }
        }
        //public ApplicationUser GetAll(UserManager<ApplicationUser> user)
        //{
        //    return ;
        //}
    }
}

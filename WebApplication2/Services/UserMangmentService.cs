using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UserMangmentService
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> UserManager;
        public UserMangmentService(ApplicationDbContext CurrentContext, UserManager<ApplicationUser> usermanager)
        {
            db = CurrentContext;
            UserManager = usermanager;
        }
        public List<ApplicationUser> GetAll()
        {
            return db.Users.Where(item => item.Deleted != true).ToList();
        }
        public List<ApplicationRole> GetAllRoles()
        {
            return db.Roles.ToList();
        }
        public List<ApplicationUser> SearchByUsername(string username)
        {
            var res = db.Users.Where(u => u.UserName.Contains(username)).ToList();
            return res;
        }
        public void BlockUser(string userID)
        {
            var res = db.Users.Find(userID);
            res.Blocked = !res.Blocked;
            db.SaveChanges();
        }
        public void DeleteUser(string userID)
        {
            var res = db.Users.Find(userID);
            res.Deleted = !res.Deleted;
            db.SaveChanges();
        }
        public void CreateUser(ApplicationUser User)
        {
            db.Users.Add(User);
            db.SaveChanges();
            //var result = await UserManager.CreateAsync(User, password);
            //var x = result.Succeeded;
        }

        public async void HashPassword(ApplicationUser user, string password)
        {
            var res=await UserManager.AddPasswordAsync(user, password);
        }



    }
}

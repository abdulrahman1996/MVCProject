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
      
        //public  GetCurrentUSer(ApplicationUser user)
        //{
        //    var res = db.Users.FirstOrDefault(p => p.Id == user.Id).Id;
        //    return ;
        //}
    }
}

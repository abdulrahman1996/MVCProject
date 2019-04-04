using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UserMangmentService
    {
        private ApplicationDbContext db;
        public UserMangmentService(ApplicationDbContext CurrentContext)
        {
            db = CurrentContext;
        }
        public List<ApplicationUser> GetAll()
        {
            return db.Users.ToList();
        }
        public List<ApplicationRole> GetAllRoles()
        {
            return db.Roles.ToList();
        }

    }
}

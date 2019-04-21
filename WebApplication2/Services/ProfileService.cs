using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Services
{
    public class ProfileService
    {
        private ApplicationDbContext db;
        public ProfileService(ApplicationDbContext d)
        {
            db = d;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Services
{
    public class RoleMangmentService
    {
        private ApplicationDbContext dbContext;
        public RoleMangmentService(ApplicationDbContext Context)
        {
            this.dbContext = Context;
        }
        public List<ApplicationRole> GetAll()
        {
            return dbContext.Roles.Where(R=>R.Deleted==false).ToList();
        }
        public void AddRole(ApplicationRole role)
        {
            if (role != null)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
        public void EditRole(ApplicationRole role)
        {
            if (role != null)
            {
                ApplicationRole applicationRole = dbContext.Roles.FirstOrDefault(r => r.Id == role.Id);
                applicationRole.Name = role.Name;
                applicationRole.Description = role.Description;
                dbContext.SaveChanges();

            }
        }
        public void Delete(string id)
        {
            ApplicationRole applicationRole = dbContext.Roles.FirstOrDefault(r => r.Id == id);
            applicationRole.Deleted = true;
            dbContext.SaveChanges();
        }
    }
}

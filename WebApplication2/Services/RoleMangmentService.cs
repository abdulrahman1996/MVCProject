using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class RoleMangmentService
    {
        private ApplicationDbContext dbContext;
        private RoleManager<ApplicationRole> RoleManager;
        public RoleMangmentService(ApplicationDbContext Context,RoleManager<ApplicationRole> roleManager)
        {
            this.dbContext = Context;
            this.RoleManager = roleManager;
        }
        public List<ApplicationRole> GetAll()
        {
            return dbContext.Roles.ToList().Where(i => i.Deleted == false).ToList();
        }

        public void EditRoleAsync(ApplicationRole role)
        {
            if (role != null)
            {
                ApplicationRole applicationRole = dbContext.Roles.FirstOrDefault(r => r.Id == role.Id);
                applicationRole.Name = role.Name;
               // var result = await RoleManager.UpdateAsync(role);
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

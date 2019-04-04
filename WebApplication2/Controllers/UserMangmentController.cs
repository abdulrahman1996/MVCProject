using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    //for admin only
    public class UserMangmentController : Controller
    {
        private readonly UserMangmentService UserService;
        private ApplicationDbContext db;
        public UserMangmentController(UserMangmentService service,ApplicationDbContext context)
        {
            UserService = service;
            db = context;
        }
        public IActionResult Index()
        {
            var res = db.Roles.ToList();
            ViewBag.AllRoles = res;
            return View(UserService.GetAll());
        }
        public  IActionResult GetAll()
        {
            var res = db.Roles.ToList();
            Debug.WriteLine(res);
           // ViewBag.AllRoles = res;
            ViewBag.AllRoles = new SelectList(db.Roles, "Id", "Name");

            return PartialView(UserService.GetAll());
        }
        public List<ApplicationUser> SearchUser()

        {
          //  Service.GetAll();
            throw new NotImplementedException();
        }
         
        public void Block(int Id)
        {

        }
        public void CreateUser(ApplicationUser  user )
        {

        } 
        public void DeleteUser()
        {

        }

    }
}
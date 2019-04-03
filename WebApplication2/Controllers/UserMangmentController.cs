using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    //for admin only
    public class UserMangmentController : Controller
    {
        private readonly UserMangmentService Service;
        public UserMangmentController(UserMangmentService service)
        {
            //kj
            //hahah
            Service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public List<ApplicationUser> SearchUser()

        {
            Service.GetAll();
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
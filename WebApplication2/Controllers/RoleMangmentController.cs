using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Models;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class RoleMangmentController : Controller
    {
        private readonly RoleMangmentService Service;
        public RoleMangmentController(RoleMangmentService service)
        {
            Service = service;
        }
        //public RoleMangmentController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        //public RoleMangmentController(RoleMangmentService service)
        //{
        //    Service = service;
        
     

        public IActionResult Index()
        {
            return View(Service.GetAll());
        }
        public IActionResult GetAll()
        {
            return PartialView(Service.GetAll());         
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(ApplicationRole applicationRole)
        {
            Service.AddRole(applicationRole);
            return PartialView("GetAll", Service.GetAll());
        }
        public IActionResult Edit(string id)
        {
            return PartialView(Service.GetAll().Find(i=>i.Id==id));
        }
        [HttpPost]
        public IActionResult Edit(ApplicationRole applicationRole)
        {
            Service.EditRole(applicationRole);

            return PartialView("GetAll", Service.GetAll());
        }

        public IActionResult Delete(string id)
        {
            Service.Delete(id);
            return PartialView("GetAll", Service.GetAll());
        }
    }
}
using System;
using Microsoft.AspNetCore.Identity;
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
        private RoleManager<ApplicationRole> RoleManager;
        private readonly RoleMangmentService Service;
        public RoleMangmentController(RoleMangmentService service, RoleManager<ApplicationRole> roleManager)
        {
            Service = service;
            RoleManager = roleManager;
        }     

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
        //public async Task<> AddRoleAsync(ApplicationRole role)
        //{
        //    var identity = await RoleManager.CreateAsync(role);
        //    var check = identity.Succeeded;
        //}
        [HttpPost]
        public async  Task <IActionResult> Create(ApplicationRole applicationRole)
        {

            var identity = await RoleManager.CreateAsync(applicationRole);
            var check = identity.Succeeded;
            return PartialView("GetAll", Service.GetAll());
        }
        public IActionResult Edit(string id)
        {
            return PartialView(Service.GetAll().Find(i=>i.Id==id));
        }
        [HttpPost]
        public IActionResult Edit(ApplicationRole applicationRole)
        {
            Service.EditRoleAsync(applicationRole);

            return PartialView("GetAll", Service.GetAll());
        }

        public IActionResult Delete(string id)
        {
            Service.Delete(id);
            return PartialView("GetAll", Service.GetAll());
        }
    }
}
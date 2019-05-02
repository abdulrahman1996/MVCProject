using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private UserManager<ApplicationUser> UserManager;

        public HttpContext HttpContext { get; set; }
        public ProfileService(ApplicationDbContext d, UserManager<ApplicationUser> _userManager, IHttpContextAccessor httpContext)
        {
            db = d;
            UserManager = _userManager;
            HttpContext = httpContext.HttpContext;

        }
        //public ApplicationUser GetUser(string id)
        //{
        //    return db.Users.Find(id);
        //}
        public void EditPhotoAsync(ApplicationUser um)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            if (um != null)
            {
                applicationUser = db.Users.FirstOrDefault(r => r.Id.Equals(um.Id));
                applicationUser.UserName = um.UserName;
                applicationUser.ImagePath = um.ImagePath;
                applicationUser.PhoneNumber = um.PhoneNumber;
                applicationUser.Gender = um.Gender;
                applicationUser.City = um.City;
                applicationUser.Country = um.Country;
                db.SaveChanges();
            }
        }
            public ApplicationUser EditAsync(ApplicationUser um)
        {

            ApplicationUser applicationUser = um;
            if (um != null)
            {

                applicationUser = db.Users.FirstOrDefault(r => r.Id.Equals(um.Id));
                applicationUser.UserName = um.UserName;
                applicationUser.PhoneNumber = um.PhoneNumber;
                applicationUser.Gender = um.Gender;
                applicationUser.City = um.City;
                applicationUser.Country = um.Country;
                db.SaveChanges();

            }
            return applicationUser;
        }
        //public  GetCurrentUSer(ApplicationUser user)
        //{
        //    return;
        //}
        ///////////////////////////////////////////////////////////////////////\
        public List<Post> GetAllUserPosts(string userID)
        {
            return db.Posts.Include(usr => usr.User).Include(likes => likes.Likes).Include(comm => comm.Comments).Where(p => p.UserID == userID && p.Deleted != true).OrderByDescending(item => item.Timestamp).ToList();

        }

        public string GetUserID(string name)
        {
            return db.Users.Where(usr => usr.UserName == name).Select(usr=>usr.Id).FirstOrDefault();
        }

        public ApplicationUser GetUser(string ID)
        {
            return db.Users.Where(usr => usr.Id == ID).FirstOrDefault();
        }


    }
}

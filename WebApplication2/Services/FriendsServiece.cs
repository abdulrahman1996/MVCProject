using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using WebApplication2.Enums;

namespace WebApplication2.Services
{
    public class FriendsServiece 
    {

        private readonly ApplicationDbContext db;
        private readonly UserMangmentService userMangmentService; 
        public FriendsServiece(ApplicationDbContext context  , UserMangmentService userMangmentService )
        {
            this.db = context;
            this.userMangmentService = userMangmentService;
        }

        public IEnumerable<frindRequestDetail> SearchFreinds(string Name)
        {

            return (from u in db.Users
                    where u.UserName.Contains(Name)
                    from f in db.FriendRequests
                    .Where(f => f.RequestedID == u.Id || f.RequesterID == u.Id)
                    .DefaultIfEmpty()
                    select new frindRequestDetail
                    {
                        Id = u.Id,
                        ImagePath = u.ImagePath,

                        UserName = u.UserName,
                        City = u.City,
                        Email = u.Email,

                        RequestedID = f.RequestedID == null ? null : f.RequestedID,
                        RequesterID = f.RequesterID == null ? null : f.RequesterID,
                        State = FriendState.NotFriend
                    });
        
                      

                        

                       //  where u.UserName.Contains(Name)



           // return userMangmentService.SearchByUsername(Name) ;

        }
       
    }
}

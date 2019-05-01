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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Services
{
    public class FriendsServiece 
    {

        private string LogginedId;

        private readonly ApplicationDbContext db;
        private readonly UserMangmentService userMangmentService;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly HttpContext httpContext;
        
        public FriendsServiece(IHttpContextAccessor http  , UserManager<ApplicationUser> usermanager , ApplicationDbContext context  , UserMangmentService userMangmentService )
        {
            
            this.UserManager = usermanager;
            this.httpContext = http.HttpContext;
            this.db = context;
            this.userMangmentService = userMangmentService;
            LogginedId = UserManager.GetUserId(httpContext.User);
        }



        public void AddFriend(string Id )
        {
            db.FriendRequests.Add(new FriendRequest()
            {
                RequestedID = Id,
                RequesterID =  LogginedId,
                State = FriendState.NotFriend
            });

            db.SaveChanges();
        }



        public IEnumerable<frindRequestDetail> GetAllFrinds()
        {


            var users = db.Users.ToList();
                              

            List<frindRequestDetail> frinds = new List<frindRequestDetail>();

            var friends = db.FriendRequests
                .Where(f =>( f.RequesterID == LogginedId || f.RequestedID == LogginedId ) && f.State== FriendState.Friend);

            foreach (var item in users)
            {

                var r = friends.FirstOrDefault(o => o.RequesterID == item.Id || o.RequestedID == item.Id);


                if (r == null)
                    frinds.Add(new frindRequestDetail()
                    {
                        Id = item.Id,
                        Email = item.Email,
                        City = item.City,

                        ImagePath = item.ImagePath,
                        State = FriendState.NotFriend,
                        UserName = item.UserName
                    });
                else
                    frinds.Add(new frindRequestDetail()
                    {
                        Id = item.Id,
                        Email = item.Email,
                        City = item.City,
                        ImagePath = item.ImagePath,
                        State = r.State,
                        UserName = item.UserName
                    });


            }




            return frinds;




        }

        public void RemoveRequest(string id)
        {
            DeleteFriend(id);
        }

        public IEnumerable<frindRequestDetail> SearchFreinds(string Name)
        {

            var users = db.Users.Where(u => u.UserName.Contains(Name) && !u.Id.Equals(LogginedId))
                                  .ToList();

            List<frindRequestDetail> details = new List<frindRequestDetail>();

            var requests = db.FriendRequests
                .Where(f => f.RequesterID == LogginedId || f.RequestedID == LogginedId)
                .Where(f=> !f.Deleted);
            
            foreach (var item in users)
            {

                
                var r = requests.FirstOrDefault(o => o.RequesterID == item.Id || o.RequestedID == item.Id);


                if(r==null )
                details.Add(new frindRequestDetail()
                {
                    Id = item.Id,
                    Email = item.Email,
                    City = item.City,
    
                    ImagePath = item.ImagePath,
                    State = FriendState.NotFriend,
                    UserName = item.UserName
                });
                else
                    details.Add(new frindRequestDetail()
                    {
                        Id = item.Id,
                        Email = item.Email,
                        City = item.City,
                        ImagePath = item.ImagePath,
                        State = GetFriendShipState(r.RequestedID , r.RequesterID ,r.State),
                        UserName = item.UserName
                    });


            }


        

            return details; 




      
 

        }
        public FriendState GetFriendShipState(string RequestedID , string RequesterID   , FriendState state)
        {
            if (state == FriendState.Friend)
                return state;

            if (RequesterID == null || RequestedID == null)
                return FriendState.NotFriend;

           
            if (RequestedID == LogginedId)
                return FriendState.Requested;

            return FriendState.Requester;
        }

        

        public void AcceptRequest(string id)
        {
            try
            {
                var friend = db.FriendRequests
                              .Where(r=> !r.Deleted)  
                              .Where(f => f.RequestedID.Equals(LogginedId) && f.RequesterID.Equals(id))
                              .FirstOrDefault();

                friend.State = FriendState.Friend;

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }
            
        }

        public void DeleteFriend(string id)
        {


            var request = db.FriendRequests.
                Where(r => !r.Deleted).
                Where(r => (r.RequestedID.Equals(LogginedId) && r.RequesterID.Equals(id)) || (r.RequesterID.Equals(LogginedId) && r.RequestedID.Equals(id)))
                .FirstOrDefault();

            request.Deleted = true; 

            db.SaveChanges();
        }

       
       





       
    }
}

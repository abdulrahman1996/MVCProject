using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{

    public class UserHomeService
    {
        private ApplicationDbContext db;
        public UserHomeService(ApplicationDbContext CurrentContext)
        {
            db = CurrentContext;
        }

        public void AddUserPost(Post Post)
        {
            db.Posts.Add(Post);
            db.SaveChanges();
        }
        public List<Post> GetAllPosts()
        {
            return db.Posts.Include(usr => usr.User).Include(likes => likes.Likes).Include(comm => comm.Comments).Where(item => item.Deleted != true).OrderByDescending(item => item.Timestamp).ToList();
        }
        public int LikesCount(int postid)
        {
            var res = db.Likes.Where(item => item.Post.ID == postid && item.Deleted == false).ToList();
            return res.Count;
        }
        public void IncrementLikes(int postId, string userid)
        {
            var user = db.Users.Where(item => item.Id == userid).FirstOrDefault();
            var post = db.Posts.Where(item => item.ID == postId).FirstOrDefault();

            var checkExist = db.Likes.Where(item => item.Post.ID == postId && item.User.Id == userid).FirstOrDefault();
            if (checkExist == null)
            {
                Like newLike = new Like()
                {
                    User = user,
                    Post = post,
                    Deleted = false
                };
                db.Likes.Add(newLike);
            }
            else
            {
                checkExist.Deleted = !checkExist.Deleted;

            }
            db.SaveChanges();



        }

        public void AddComment(string content, int postId, string userid)
        {
            var user = db.Users.Where(item => item.Id == userid).FirstOrDefault();
            var post = db.Posts.Where(item => item.ID == postId).FirstOrDefault();
            Comment comm = new Comment()
            {
                Content = content,
                User = user,
                Post = post,
                Deleted = false
            };
            db.Comments.Add(comm);
            db.SaveChanges();
        }

        public List<ApplicationUser> GetAllLikes(int postId)
        {
            var users = db.Likes.Where(item => item.Post.ID == postId && item.Deleted==false).Select(u=>u.User).ToList();
            return users;
        }

        public void DeletePost(int postid)
        {
            var comment = db.Comments.Where(comm => comm.Post.ID == postid).ToList();
            var like = db.Likes.Where(comm => comm.Post.ID == postid).ToList();
            
            if(comment.Count!=0)
            {
                comment.ForEach(comm => comm.Deleted = true);
            }

            if (like.Count != 0)
            {
                like.ForEach(lik => lik.Deleted = true);
            }

            db.Posts.Where(post => post.ID == postid).FirstOrDefault().Deleted=true;
            db.SaveChanges();
        }

        public void DeleteComment(int commentid)
        {
            db.Comments.Where(comment => comment.ID == commentid).FirstOrDefault().Deleted = true;
            db.SaveChanges();
        }

    }
}

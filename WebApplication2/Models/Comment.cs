using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }
        public bool Deleted { get; set; }

    }
}

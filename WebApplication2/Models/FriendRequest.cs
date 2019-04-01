using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }
        [Required]
        public int State { get; set; }
        [ForeignKey("RequesterID")]
        public virtual ApplicationUser Requester { get; set; }
        [ForeignKey("RequestedID")]
        public virtual ApplicationUser Requested { get; set; }
    }
}

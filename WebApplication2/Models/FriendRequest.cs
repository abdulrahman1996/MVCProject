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
        public FriendRequest State { get; set; }
        [ForeignKey("Requester")]
        public string RequesterID { set; get; }

        public virtual ApplicationUser Requester { get; set; }

        [ForeignKey("Requested")]
        public string RequestedID { set; get; }

        public virtual ApplicationUser Requested { get; set; }
        public bool Deleted { get; set; }
    }
}

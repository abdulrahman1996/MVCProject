using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
            :base()
        {

        }

        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            :base()
        {

        }

        public string Description { get; set; }
    }
}

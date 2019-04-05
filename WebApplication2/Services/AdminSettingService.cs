using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class AdminSettingService
    {
        private UserManager<ApplicationUser> UserManager;

        public HttpContext HttpContext { get; set; }

        public AdminSettingService(UserManager<ApplicationUser> _userManager , IHttpContextAccessor httpContext)
        {
            UserManager = _userManager;
            HttpContext = httpContext.HttpContext;

        }

        public async Task<ApplicationUser> EditUserAsync(string Email , string UserName)
        {
            var user = await GetUser();
            user.Email = Email;
            user.UserName = UserName;
            await UserManager.UpdateAsync(user);
            return user;
        }


        public async Task<IdentityResult> ChangePasswordAsync(string OldPassword , string NewPassword)
        => await UserManager.ChangePasswordAsync(await GetUser(), OldPassword, NewPassword);
           
        
        public async Task<ApplicationUser> GetUser() => await UserManager.GetUserAsync(HttpContext.User);

}
}

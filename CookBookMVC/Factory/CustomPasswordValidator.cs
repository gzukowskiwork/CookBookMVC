using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Factory
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            string username = await manager.GetUserNameAsync(user);

            if (username.ToLower().Equals(password.ToLower()))
            {
                return IdentityResult.Failed(new IdentityError { Description = "SameUserPass", Code = "Username and Password can't be the same." });
            }
            if (password.ToLower().Contains("password"))
            {
                return IdentityResult.Failed(new IdentityError { Code = "PasswordContainsPassword", Description = "The word password is not allowed." });
            }
            if (password.ToLower().Contains(username))
            {
                return IdentityResult.Failed(
                    new IdentityError 
                    { 
                    Description = "PasswordContainsUsername", 
                    Code = "Password can't contain username." 
                    });

            }

            return IdentityResult.Success;
        }
    }
}

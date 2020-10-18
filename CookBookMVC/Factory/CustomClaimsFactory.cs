using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookBookMVC.Factory
{
    public class CustomClaimsFactory: UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CustomClaimsFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> options )
            :base (userManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Nick", user.UserName));
            return identity;
        }
    }
}

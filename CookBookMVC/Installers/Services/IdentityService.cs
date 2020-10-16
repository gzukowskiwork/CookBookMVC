using CookBookMVC.Factory;
using CpntextLib.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models.Identity;
using System;

namespace CookBookMVC.Installers.Services
{
    public class IdentityService : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

                options.Lockout.AllowedForNewUsers = true;
                //Todo chnage to 30 after testing
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;
                
            })
            .AddEntityFrameworkStores<CookBookContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation");

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromHours(1));

            services.Configure<EmailConfirmationTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromDays(2));

        }
    }
}

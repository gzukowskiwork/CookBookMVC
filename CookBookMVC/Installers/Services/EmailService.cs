﻿using EmailLib.EmailConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CookBookMVC.Installers.Services
{
    public class EmailService : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Installers.Services
{
    public class EmailService : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailService>();
            services.AddSingleton(emailConfig);
        }
    }
}

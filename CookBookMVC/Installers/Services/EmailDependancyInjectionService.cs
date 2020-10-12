using EmailLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CookBookMVC.Installers.Services
{
    public class EmailDependancyInjectionService:IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISendEmail, EmailSender>();
        }
    }
}

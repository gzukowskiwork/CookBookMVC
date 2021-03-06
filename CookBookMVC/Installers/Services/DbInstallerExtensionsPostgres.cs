﻿using CookBookMVC.Installers;
using CpntextLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBookMVC.Extensions
{
    public class DbInstallerExtensionsPostgres: IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["connection:connectionString"];
            services.AddDbContext<CookBookContext>(o =>
                o.UseSqlServer(connectionString));
        }
    }
}

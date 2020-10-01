﻿using CpntextLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.MigrationsManager
{
    public static class MigrationsManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using(var appContext = scope.ServiceProvider.GetRequiredService<CookBookContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch
                    {

                    }
                }
            }
            return host;
        }
    }
}

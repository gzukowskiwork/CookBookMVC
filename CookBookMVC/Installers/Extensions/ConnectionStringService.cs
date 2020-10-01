using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Installers.Extensions

{
    public static class ConnectionStringService
    {
        public static string GetConnectionString(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("connection")?[name];
        }
    }
}

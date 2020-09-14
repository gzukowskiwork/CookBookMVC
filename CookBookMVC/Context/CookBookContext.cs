using CookBookMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Context
{
    public class CookBookContext: DbContext
    {
        public DbSet<ImageModel> ImageModels { get; set; }
        public DbSet<IngredientModel> IngredientModels { get; set; }
        public DbSet<RecipeModel> RecipeModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CookBook;Username=postgres;Password=Password!1");
    
        public CookBookContext(DbContextOptions<CookBookContext> options): base(options)
        {

        }
    
    }
}

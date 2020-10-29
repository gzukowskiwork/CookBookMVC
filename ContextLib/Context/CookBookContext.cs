using ContextLib.Confg;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.Identity;

namespace CpntextLib.Context
{
    public class CookBookContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Image> ImageModels { get; set; }
        public DbSet<ImageIngredient> ImageIngredients { get; set; }
        public DbSet<Ingredient> IngredientModels { get; set; }
        public DbSet<ImageRecipe> ImageRecipes { get; set; }
        public DbSet<Recipe> RecipeModels { get; set; }

        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImageRecipe>()
                .HasKey(ir => new { ir.ImageId, ir.RecipeId });

            modelBuilder.Entity<ImageRecipe>()
                .HasOne(ir => ir.Image)
                .WithMany(i => i.ImageRecepies)
                .HasForeignKey(ir => ir.ImageId);

            modelBuilder.Entity<ImageRecipe>()
                .HasOne(ir => ir.Recipe)
                .WithMany(r => r.ImageRecipes)
                .HasForeignKey(ir => ir.RecipeId);


            modelBuilder.Entity<ImageIngredient>()
                .HasKey(ii => new { ii.ImageId, ii.IngredientId });

            modelBuilder.Entity<ImageIngredient>()
                .HasOne(ii => ii.Image)
                .WithMany(i => i.ImageIngredients)
                .HasForeignKey(ii => ii.ImageId);

            modelBuilder.Entity<ImageIngredient>()
                .HasOne(ii=>ii.Ingredient)
                .WithMany(i=>i.ImageIngredients)
                .HasForeignKey(ii=>ii.IngredientId);

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(r => r.IngredientId);

            modelBuilder.Entity<Ingredient>()
                .HasOne(ic => ic.IngredientCount)
                .WithOne(i => i.Ingredient)
                .HasForeignKey<IngredientCount>(ic => ic.IngredientId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany(x => x.Comments)
                .HasForeignKey(c=>c.RecipeId);

            modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
        }
    }
}

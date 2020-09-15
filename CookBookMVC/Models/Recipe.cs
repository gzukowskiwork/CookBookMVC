using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookBookMVC.Models
{
    public class Recipe
    {
        [Key]
        public string RecipeId { get; set; }
        
        [Display(Name ="Sposób przyrządzenia:")]
        public string Description { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }

        public List<ImageRecipe> ImageRecipes { get; set; }
    }
}

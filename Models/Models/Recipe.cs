using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Recipe
    {
        [Key]
        public string RecipeId { get; set; }

        [Required]
        [Display(Name ="Nazwa przepisu")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name ="Sposób przyrządzenia:")]
        public string Description { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }

        public List<ImageRecipe> ImageRecipes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

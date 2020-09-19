using System.Collections.Generic;


namespace Models.Models.ViewModels
{
    public class RecipeIngredientImageViewModel
    {
        public IEnumerable<Image> ImageModels { get; set; }
        public IEnumerable<Ingredient> IngredientModels { get; set; }
        public IEnumerable<Recipe> RecipeModels { get; set; }
        public IEnumerable<IngredientCount> IngredientCounts { get; set; }
    }
}

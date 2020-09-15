using System.ComponentModel.DataAnnotations.Schema;


namespace CookBookMVC.Models
{
    public class IngredientCount
    {
        public string RecipeCountId { get; set; }

        public int? Count { get; set; }

        [ForeignKey(name: "IngredientId")]
        public string IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}

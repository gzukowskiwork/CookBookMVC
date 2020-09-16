using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CookBookMVC.Models
{
    public class IngredientCount
    {
        [Key]
        public string RecipeCountId { get; set; }

        [Display(Name ="Ilość")]
        public int? Count { get; set; }

        [ForeignKey(name: "IngredientId")]
        public string IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}

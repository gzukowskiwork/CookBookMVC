using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CookBookMVC.Models
{
    public class Ingredient
    {
        [Key]
        public string IngredientId { get; set; }

        [Display(Name = "Nazwa")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Energia (KCal)")]
        public string Energy { get; set; }

        [Display(Name = "Przeciętna cena")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public Recipe Recipe { get; set; }

        public IngredientCount IngredientCount { get; set; }

        public List<ImageIngredient> ImageIngredients { get; set; }
    }
}

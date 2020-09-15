using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CookBookMVC.Models
{
    public class Image
    {
        [Key]
        public string ImageId { get; set; }

        [Display(Name ="Tytuł")]
        public string Title { get; set; }

        [Display(Name ="Nazwa zdjęcia")]
        [Required]
        public string ImageName { get; set; }
        
        [ForeignKey(name:"RecipeId")]
        public List<ImageRecipe> ImageRecepies { get; set; }

        [ForeignKey(name:"IngredientId")]
        public List<ImageIngredient> ImageIngredients { get; set; }

    }
}

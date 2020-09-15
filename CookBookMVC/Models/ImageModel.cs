using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CookBookMVC.Models
{
    public class ImageModel
    {
        [Key]
        public string Id { get; set; }

        [Display(Name ="Tytuł")]
        public string Title { get; set; }

        [Display(Name ="Nazwa zdjęcia")]
        [Required]
        public string ImageName { get; set; }
        
        [ForeignKey(name:"Id")]
        public RecipeModel Recepie { get; set; }

        [ForeignKey(name:"Id")]
        public IngredientModel Ingredient { get; set; }

    }
}

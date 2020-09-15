using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Models
{
    public class RecipeModel
    {
        [Key]
        public string Id { get; set; }
        
        [Display(Name ="Sposób przyrządzenia:")]
        public string Description { get; set; }
        
        public List<IngredientModel> Ingredients { get; set; }

        public List<ImageModel> Images { get; set; }
    }
}

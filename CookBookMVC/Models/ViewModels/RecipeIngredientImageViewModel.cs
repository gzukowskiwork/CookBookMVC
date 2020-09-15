using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Models.ViewModels
{
    public class RecipeIngredientImageViewModel
    {
        public IEnumerable<ImageModel> ImageModels { get; set; }
        public IEnumerable<IngredientModel> IngredientModels { get; set; }
        public IEnumerable<RecipeModel> RecipeModels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookMVC.Models
{
    public class IngredientModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Nazwa")]
        [Required]
        public string Name { get; set; }
        public string Energy { get; set; }
        public string Price { get; set; }

        public List<ImageModel>Images { get; set; }

    }
}

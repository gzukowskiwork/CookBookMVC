using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
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

        [Display(Name="Energia (KCal)")]
        public string Energy { get; set; }

        [Display(Name ="Przeciętna cena")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public List<ImageModel>Images { get; set; }

    }
}

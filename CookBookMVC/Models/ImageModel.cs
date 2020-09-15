using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CookBookMVC.Models
{
    public class ImageModel
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public RecipeModel Recepie { get; set; }


    }
}

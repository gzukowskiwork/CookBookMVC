

namespace Models.Models
{
    public class ImageIngredient
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}

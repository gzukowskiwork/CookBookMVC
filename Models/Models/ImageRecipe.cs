
namespace Models.Models
{
    public class ImageRecipe
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}

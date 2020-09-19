using Interfaces.Repository;

namespace Wrapper.Repository
{
    public interface IRepositoryWrapper
    {
        IImageRepository ImageRepository { get; }
        //IIngredientRepository IngredientRepository { get; }
        IIngredientCountRepository IngredientCountRepository { get; }
        //IRecipeRepository RecipeRepository { get; }
        void Save();
    }
}

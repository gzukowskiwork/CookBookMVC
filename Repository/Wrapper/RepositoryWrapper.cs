using CpntextLib.Context;
using Interfaces.Repository;
using Repository.Repository;
using Wrapper.Repository;

namespace Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CookBookContext _cookBookContext;
        private IImageRepository _imageRepository;
        private IIngredientCountRepository _ingredientCountRepository;
        private IIngredientRepository _ingredientRepository;
        private IRecipeRepository _recipeRepository;

        public RepositoryWrapper(CookBookContext cookBookContext)
        {
            _cookBookContext = cookBookContext;
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if(_imageRepository is null)
                {
                    _imageRepository = new ImageRepository(_cookBookContext);
                }
                return _imageRepository; 
            }
        }

        public IIngredientCountRepository IngredientCountRepository
        {
            get
            {
                if (_ingredientCountRepository is null)
                {
                    _ingredientCountRepository = new IngredientCountRepository(_cookBookContext);
                }
                return _ingredientCountRepository;
            }
        }

        public IIngredientRepository IngredientRepository
        {
            get
            {
                if (_ingredientRepository is null)
                {
                    _ingredientRepository = new IngredientRepository(_cookBookContext);
                }
                return _ingredientRepository;
            }
        }

        public IRecipeRepository RecipeRepository
        {
            get
            {
                if (_recipeRepository is null)
                {
                    _recipeRepository = new RecipeRepository(_cookBookContext);
                }
                return _recipeRepository;
            }
        }

        public void Save()
        {
            _cookBookContext.SaveChangesAsync();
        }
    }
}

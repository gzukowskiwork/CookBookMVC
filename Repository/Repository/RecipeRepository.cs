using CpntextLib.Context;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RecipeRepository:RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookBookContext cookBookContext): base(cookBookContext)
        {

        }

        public async Task<IQueryable<string>> GetRecipeWithImageByRecipeId(string recipeId)
        {

            //ToDO make it work!!
            IQueryable<string> dupa;
            var xx = await CookBookContext.ImageRecipes.Where(r => r.RecipeId.Equals(recipeId)).Select(x => x.ImageId).ToListAsync();
           
            foreach (var item in xx)
            {
                dupa = CookBookContext.ImageModels.Where(x => x.ImageId.Equals(item)).Select(z=>z.ImageName);
                return dupa;
            }
            return null;

        }
    }
}

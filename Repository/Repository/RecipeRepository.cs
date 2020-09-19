using CpntextLib.Context;
using Interfaces.Repository;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class RecipeRepository:RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookBookContext cookBookContext): base(cookBookContext)
        {

        }
    }
}

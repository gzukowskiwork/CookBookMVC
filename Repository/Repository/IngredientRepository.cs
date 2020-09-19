using CpntextLib.Context;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class IngredientRepository: RepositoryBase<IngredientRepository>, IIngredientRepository
    {
        public IngredientRepository(CookBookContext cookBookContext): base(cookBookContext)
        {

        }
    }
}

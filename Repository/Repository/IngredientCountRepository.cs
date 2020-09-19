using CpntextLib.Context;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class IngredientCountRepository: RepositoryBase<IngredientCountRepository>, IIngredientCountRepository
    {
        public IngredientCountRepository(CookBookContext cookBookContext) : base(cookBookContext)
        {

        }
    }
}

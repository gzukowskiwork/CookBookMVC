using CpntextLib.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CookBookContext CookBookContext { get; set; }

        public RepositoryBase(CookBookContext cookBookContext)
        {
            CookBookContext = cookBookContext;
        }

        public void Create(T entity)
        {
            CookBookContext.Set<T>().Add(entity); 
        }

        public void Delete(T entity)
        {
            CookBookContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return CookBookContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return CookBookContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            CookBookContext.Set<T>().Update(entity);
        }
    }
}

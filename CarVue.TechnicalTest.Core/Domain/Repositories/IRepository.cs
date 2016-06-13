using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public interface IRepository<T>
        where T : class, new()
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string include = "");

        T GetById(object id);

        void Insert(T entity);

        void Delete(object id);

        void Delete(T entity);

        void Update(T entity);
    }
}
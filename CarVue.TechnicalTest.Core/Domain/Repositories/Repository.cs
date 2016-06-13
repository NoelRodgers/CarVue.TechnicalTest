using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CarVue.TechnicalTest.Common.UnitOfWorkPattern;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string include = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null) query = query.Where(filter);

            include.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(x => query = query.Include(x));

            return orderBy != null 
                    ? orderBy(query).ToList() 
                    : query.ToList();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
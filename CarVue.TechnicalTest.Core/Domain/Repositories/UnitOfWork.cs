using System;
using System.Data.Entity;
using CarVue.TechnicalTest.Common.UnitOfWorkPattern;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext == null) return;
            _dbContext.Dispose();
            _dbContext = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
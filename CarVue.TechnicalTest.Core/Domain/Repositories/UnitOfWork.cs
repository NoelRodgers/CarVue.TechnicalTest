using System;
using System.Data.Entity;
using CarVue.TechnicalTest.Core.Domain.Repositories.Items;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechnicalTestDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork(TechnicalTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAllChanges()
        {
            _dbContext.SaveChanges();
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext));

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
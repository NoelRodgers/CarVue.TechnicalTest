using System;
using CarVue.TechnicalTest.Core.Domain.Repositories.Items;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveAllChanges();

        IUserRepository UserRepository { get; }
    }
}
using System;

namespace CarVue.TechnicalTest.Common.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
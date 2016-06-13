using System.Data.Entity;
using CarVue.TechnicalTest.Common.UnitOfWorkPattern;
using CarVue.TechnicalTest.Core.Domain;
using CarVue.TechnicalTest.Core.Domain.Repositories;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
using StructureMap.Web.Pipeline;

namespace CarVue.TechnicalTest.Core.IoC
{
    public class DomainIoC : Registry
    {
        public DomainIoC()
        {
            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<TechnicalTestDbContext>();
            For<IUnitOfWork>().LifecycleIs(new HttpContextLifecycle()).Use<UnitOfWork>();
        }
    }
}
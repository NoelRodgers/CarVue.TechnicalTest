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
            //TODO In the morning - either turn this into a factory so it can called with the using for immediate disposal
            //OR continue on this path. Not sure what's best, come back to it later.
            For<TechnicalTestDbContext>().HybridHttpOrThreadLocalScoped().Use<TechnicalTestDbContext>();
            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();
        }
    }
}
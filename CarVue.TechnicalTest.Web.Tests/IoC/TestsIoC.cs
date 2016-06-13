using CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser;
using StructureMap.Configuration.DSL;

namespace CarVue.TechnicalTest.Web.Tests.IoC
{
    public class TestsIoC : Registry
    {
        public TestsIoC()
        {
            For<IBrowserFactory>().Use<BrowserFactory>();
        }
    }
}
using CarVue.TechnicalTest.Common.Configuration;
using CarVue.TechnicalTest.Common.ContentReader;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Common.Versioning;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace CarVue.TechnicalTest.Common.IoC
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<IUriContentReaderService>().Use<UriContentReaderService>();
            For<IConfigurationBuilder>().Use<ConfigurationBuilder>();
            For<IVersionManager>().Use<VersionManager>();
        }
    }
}
using System;
using System.Configuration;
using System.Linq;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Common.UnitOfWorkPattern;
using StructureMap;
using StructureMap.Graph;

namespace CarVue.TechnicalTest.Common.IoC
{
    public class Bootstrapper
    {
        public static IContainer Build()
        {
           
            var container = new Container(x =>
            {
                x.Scan(Scan);
            });
            
            container.AssertConfigurationIsValid();
            return container;            
        }

        public static void Scan(IAssemblyScanner scan)
        {
            var projectPrefix = ConfigurationManager.AppSettings["IoCProjectPrefix"];
            scan.TheCallingAssembly();
            scan.AssembliesFromApplicationBaseDirectory(
                y =>
                    y.FullName.StartsWith(projectPrefix) &&
                    !y.FullName.EndsWith("Tests"));
            scan.AddAllTypesOf(typeof(IRepository<>));
            scan.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
            scan.WithDefaultConventions();
            scan.LookForRegistries();
        }
    }
}
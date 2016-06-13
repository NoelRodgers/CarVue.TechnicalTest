using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser;
using CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser.WebDriverItems;
using StructureMap;
using StructureMap.Graph;

namespace CarVue.TechnicalTest.Web.Tests.Core
{
    public class UIContainer
    {
        public static void BootstrapContainer()
        {
            _container = new Container(x =>
            {
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.AssembliesFromApplicationBaseDirectory(z => z.FullName.Contains("CarVue") && (z.FullName.Contains("Test") || z.FullName.Contains("Common")));
                    y.LookForRegistries();
                    y.AddAllTypesOf<IBrowserItem>();
                });
                x.For<IBrowserItem>().Use<ChromeWebDriverItem>(); //TODO - Drive default from App.Config
            });
            string contents = _container.WhatDoIHave();         
        }

        private static Container _container;
        public static Container Container
        {
            get
            {
                return _container;
            }                      
        }

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
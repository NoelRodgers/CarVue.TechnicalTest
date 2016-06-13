using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser.WebDriverItems
{
    public class ChromeWebDriverItem : IBrowserItem
    {
        private readonly SpecflowSettings _settings;
        public ChromeWebDriverItem(IConfigurationBuilder configurationBuilder)
        {
            _settings = configurationBuilder.GetConfiguration<SpecflowSettings>();
        }

        public IWebDriver GetWebDriver()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("browser.cache.disk.enable", false);
            options.AddUserProfilePreference("browser.startup.homepage", "about:blank");
            options.AddUserProfilePreference("startup.homepage_override_url", "about:blank");
            options.Proxy = new Proxy { IsAutoDetect = true };            
            options.AddExcludedArgument("ignore-certificate-errors");
            var executingPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath + _settings.ChromeProfile;
            Debug.WriteLine(executingPath);
            return new ChromeDriver(executingPath, options);                        
        }

        public string BrowserType
        {
            get { return "Chrome"; }            
        }
    }
}
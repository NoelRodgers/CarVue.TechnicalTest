using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core
{
    public class UIEnvironment
    {
        private static IWebDriver _webDriver;
        public static IWebDriver WebDriver
        {
            get
            {
                if (_webDriver != null) return _webDriver;

                var builder = UIContainer.GetInstance<IConfigurationBuilder>();
                var browserType = builder.GetConfiguration<SpecflowSettings>().BrowserProfile;

                _webDriver = UIContainer.GetInstance<IBrowserFactory>().GetDriverBrowser(browserType);

                return _webDriver;
            }
        }

        public static T WebDriverAs<T>()
        {
            return (T)WebDriver;
        }

        public static void DisposeWebDriver()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }
    }
}
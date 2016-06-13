using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser
{
    public interface IBrowserFactory
    {
        IWebDriver GetDriverBrowser(string browserType);
        IWebDriver GetDefaultDriverBrowser(); 
    }
}
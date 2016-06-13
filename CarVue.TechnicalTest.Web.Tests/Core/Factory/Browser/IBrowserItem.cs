using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser
{
    public interface IBrowserItem
    {
        IWebDriver GetWebDriver();
        string BrowserType { get; }
    }
}
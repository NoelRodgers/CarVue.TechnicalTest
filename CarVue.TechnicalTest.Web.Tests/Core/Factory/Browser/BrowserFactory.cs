using System;
using System.Collections.Generic;
using System.Linq;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.Factory.Browser
{
    public class BrowserFactory : IBrowserFactory
    {
        private readonly IList<IBrowserItem> _webDriverItems;
        private readonly IBrowserItem _defaultWebDriverItem;

        public BrowserFactory(IList<IBrowserItem> webDriverItems, IBrowserItem defaultWebDriverItem)
        {
            _webDriverItems = webDriverItems;
            _defaultWebDriverItem = defaultWebDriverItem;
        }

        public IWebDriver GetDriverBrowser(string browserType)
        {
            var driver = _webDriverItems.SingleOrDefault(x => x.BrowserType == browserType);
            if (driver == null) throw new InvalidOperationException("Unable to load the '{0}' browser - No valid browser factory item was found".FormatString(browserType));
            return BuildWebDriver(driver);
        }

        public IWebDriver GetDefaultDriverBrowser()
        {
            return BuildWebDriver(_defaultWebDriverItem);
        }

        private IWebDriver BuildWebDriver(IBrowserItem browserItem)
        {
            var driver = browserItem.GetWebDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
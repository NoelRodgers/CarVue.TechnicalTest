using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CarVue.TechnicalTest.Web.Tests.Core.Extensions
{
    public static class BrowserExtensions
    {
        public static IWebElement TryFindElement(this ISearchContext driver, By findBy, bool allowWait = true)
        {
            return TryFind(driver.FindElement, findBy, allowWait);
        }

        public static ReadOnlyCollection<IWebElement> TryFindElements(this ISearchContext driver, By findBy, bool allowWait = true)
        {
            return TryFind(driver.FindElements, findBy, allowWait);
        }

        private static T TryFind<T>(Func<By, T> find, By findBy, bool allowWait)
            where T : class
        {
            while (true)
            {
                try
                {
                    if (!allowWait) return find(findBy);

                    var wait = new WebDriverWait(UIEnvironment.WebDriver, new TimeSpan(0, 0, 2));
                    wait.Until(ExpectedConditions.ElementExists(findBy));
                    return find(findBy);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }
    }
}
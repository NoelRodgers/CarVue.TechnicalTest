using System;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver.WaitConditions
{
    public class ExpectedConditionsExtensions
    {
        public static Func<IWebDriver, object> AlertVisible()
        {
            return new IsAlertVisible().AlertVisible;
        }
    }
}
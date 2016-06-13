using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver.WaitConditions
{
    public class IsAlertVisible
    {
        public IAlert AlertVisible(IWebDriver driver)
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }
    }
}
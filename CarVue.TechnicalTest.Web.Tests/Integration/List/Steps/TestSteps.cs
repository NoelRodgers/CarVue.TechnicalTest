using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CarVue.TechnicalTest.Web.Tests.Integration.List.Steps
{
    [Binding]
    public class TestSteps
    {
        [Given(@"I am on the Home page")]
        [When(@"I navigate to the Home page")]
        public void GivenIAmOnTheHomePage()
        {
            var configurationBuilder = UIContainer.Container.GetInstance<IConfigurationBuilder>();
            var settings = configurationBuilder.GetConfiguration<SpecflowSettings>();
            UIEnvironment.WebDriver.Navigate().GoToUrl(settings.BaseUrl);
        }
    }
}
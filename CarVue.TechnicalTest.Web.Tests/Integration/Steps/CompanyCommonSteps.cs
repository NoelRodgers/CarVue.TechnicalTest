using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using TechTalk.SpecFlow;

namespace CarVue.TechnicalTest.Web.Tests.Integration.Steps
{
    [Binding]
    [Scope(Tag="Common")]
    public class CompanyCommonSteps
    {
        [Given(@"I am on the Company List Page")]
        [When(@"I navigate to the Company List page")]
        public void WhenINavigateToTheCompanyListPage()
        {
            var configurationBuilder = UIContainer.Container.GetInstance<IConfigurationBuilder>();
            var settings = configurationBuilder.GetConfiguration<SpecflowSettings>();
            UIEnvironment.WebDriver.Navigate().GoToUrl(settings.BaseUrl);
        }

    }
}
using System.Linq;
using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Core.Domain;
using CarVue.TechnicalTest.Core.Domain.Items;
using CarVue.TechnicalTest.Core.Domain.Repositories;
using CarVue.TechnicalTest.Web.Tests.Core;
using CarVue.TechnicalTest.Web.Tests.Core.Extensions;
using CarVue.TechnicalTest.Web.Tests.Core.WebDriver;
using CarVue.TechnicalTest.Web.Tests.Integration.Steps.POCO;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CarVue.TechnicalTest.Web.Tests.Integration.Steps
{
    [Binding]
    [Scope(Tag = "CompanyList")]
    public class CompanyListSteps
    {
        [Given(@"I have the following companies with default information:")]
        public void GivenIHaveTheFollowingCompaniesWithDefaultInformation(Table table)
        {
            var items = table.CreateSet<CompanyDetailsSpecflowItem>();

            using (var context = new TechnicalTestDbContext())
            {
                var repository = new CompaniesRepository(context);
                var allItems = repository.Get().ToList();
                allItems.ForEach(repository.Delete);

                items.ForEach(x =>
                {
                    repository.Insert(new Company {Name = x.CompanyName});
                });
                context.SaveChanges();
            }
        }

        [Given(@"I have no companies")]
        public void GivenIHaveNoCompanies()
        {
            CleanData();
        }

        [Then(@"I should see a message '(.*)' in the '(.*)' section")]
        public void ThenIShouldSeeAMessageInTheSection(string message, string sectionName)
        {
            var section =
                UIEnvironment.WebDriver.FindElement(ByExtensions.SectionOrDivWithSpecflowDataAttribute(sectionName));
            var messageElement = section.FindElement(ByExtensions.SpecflowDataAttribute("Message"));
            Assert.AreEqual(message, messageElement.Text);
        }

        [Then(@"I should not see a list of companies in the '(.*)' section")]
        public void ThenIShouldNotSeeAListOfCompaniesInTheSection(string sectionName)
        {
            var section =
                UIEnvironment.WebDriver.FindElement(ByExtensions.SectionOrDivWithSpecflowDataAttribute(sectionName));
            var companiesTable = section.TryFindElement(By.TagName("table"), false);
            Assert.IsNull(companiesTable);
        }

        [Then(@"I should see a list of companies with the following items in the '(.*)' section:")]
        public void ThenIShouldSeeAListOfCompaniesWithTheFollowingItemsInTheSection(string sectionName, Table table)
        {
            var expectedCompanyNames = table.CreateSet<CompanyDetailsSpecflowItem>()
                                            .SelectToList(x => x.CompanyName);

            var actualTable = UIEnvironment.WebDriver
                                           .FindElement(ByExtensions.SectionOrDivWithSpecflowDataAttribute(sectionName));

            var actualCompanyNames = actualTable.FindElements(ByExtensions.SpecflowDataAttribute("Company Name"))
                                                .SelectToList(x => x.Text);


            Assert.AreEqual(expectedCompanyNames, actualCompanyNames);
        }

        [AfterScenario]
        public void CleanData()
        {
            using (var context = new TechnicalTestDbContext())
            {
                var repository = new CompaniesRepository(context);
                var allItems = repository.Get().ToList();
                allItems.ForEach(repository.Delete);
                context.SaveChanges();
            }
        }
    }
}

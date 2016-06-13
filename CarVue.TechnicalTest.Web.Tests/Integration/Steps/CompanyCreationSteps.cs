using System;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using CarVue.TechnicalTest.Web.Tests.Core.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CarVue.TechnicalTest.Web.Tests.Integration.Steps
{
    [Binding]
    [Scope(Tag="CompanyCreation")]
    public class CompanyCreationSteps
    {
        [When(@"I click on the '(.*)' link")]
        public void WhenIClickOnTheLink(string linkText)
        {
            var link = UIEnvironment.WebDriver.FindElement(By.LinkText(linkText));
            link.Click();
        }

        [Then(@"I should be on the Company Add Page")]
        public void ThenIShouldBeOnTheCompanyAddPage()
        {
            Assert.AreEqual("Add New Company", UIEnvironment.WebDriver.Title);
        }

        [Given(@"I am on the Company Add Page")]
        public void GivenIAmOnTheCompanyAddPage()
        {
            var configurationBuilder = UIContainer.Container.GetInstance<IConfigurationBuilder>();
            var settings = configurationBuilder.GetConfiguration<SpecflowSettings>();
            UIEnvironment.WebDriver.Navigate().GoToUrl(string.Join(settings.BaseUrl, "/Company") );
        }

        [When(@"I enter nothing into the '(.*)' textbox")]
        public void WhenIEnterNothingIntoTheTextbox(string textBoxName)
        {
            var textBox = UIEnvironment.WebDriver.FindElement(ByExtensions.LabelText(textBoxName));
            textBox.SendKeys(Keys.Backspace);
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonText)
        {
            var button = UIEnvironment.WebDriver.FindElement(ByExtensions.ButtonText(buttonText));
            button.Click();
        }

        [Then(@"I should see the '(.*)' validation message")]
        public void ThenIShouldSeeTheValidationMessage(string messageText)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter '(.*)' into the '(.*)' textbox")]
        public void WhenIEnterIntoTheTextbox(string text, string textBoxName)
        {
            var textBox = UIEnvironment.WebDriver.FindElement(ByExtensions.LabelText(textBoxName));
            textBox.SendKeys(text);
        }

        [Then(@"I should be taken to the Company List Page")]
        public void ThenIShouldBeTakenToTheCompanyListPage()
        {
            
        }

        [Then(@"I should see a message '(.*)'")]
        public void ThenIShouldSeeAMessage(string message)
        {
            ScenarioContext.Current.Pending();
        }

    }
}

using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByTagWithContent : By
    {
        private readonly string _tagName;
        private readonly string _contentValue;

        public ByTagWithContent(string tagName, string contentValue)
        {
            _tagName = tagName;
            _contentValue = contentValue;
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElement(BuildSelector());
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return context.FindElements(BuildSelector());
        }

 
        private By BuildSelector()
        {
            return XPath(".//{0}[contains(., '{1}')]".FormatString(_tagName, _contentValue));
        }
    }
}
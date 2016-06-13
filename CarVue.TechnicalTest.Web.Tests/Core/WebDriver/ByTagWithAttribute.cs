using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByTagWithAttribute : By
    {
        private readonly string _tagName;
        private readonly string _attributeName;
        private readonly string _attributeText;

        public ByTagWithAttribute(string tagName, string attributeName, string attributeText)
        {
            _tagName = tagName;
            _attributeName = attributeName;
            _attributeText = attributeText;            
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElement(BuildSelector());
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return context.FindElements(BuildSelector());
        }

        private string BuildAttributeSelector()
        {
            return "@{0}='{1}'".FormatString(_attributeName, _attributeText);
        }

        private By BuildSelector()
        {
            return XPath(".//{0}[{1}]".FormatString(_tagName, BuildAttributeSelector()));
        }
    }
}
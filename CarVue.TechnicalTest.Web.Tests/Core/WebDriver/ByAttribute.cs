using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByAttribute : By
    {
        private readonly string _attributeName;
        private readonly string _attributeText;

        public ByAttribute(string attributeName, string attributeText)
        {
            _attributeName = attributeName;
            _attributeText = attributeText;            
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElement(XPath(".//*[{0}]".FormatString(BuildAttributeSelector())));
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return context.FindElements(XPath(".//*[{0}]".FormatString(BuildAttributeSelector())));
        }

        private string BuildAttributeSelector()
        {
            return "@{0}='{1}'".FormatString(_attributeName, _attributeText);
        }
    }
}
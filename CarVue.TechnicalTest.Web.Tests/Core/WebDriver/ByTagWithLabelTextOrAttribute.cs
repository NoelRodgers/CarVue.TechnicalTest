using System.Collections.ObjectModel;
using System.Linq;
using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Web.Tests.Core.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByTagWithLabelTextOrAttribute : By
    {
        private readonly string _attributeName;
        private readonly string _tagName;
        private readonly string _labelText;

        public ByTagWithLabelTextOrAttribute(string tagName, string attributeName, string labelText)
        {
            _attributeName = attributeName;
            _tagName = tagName;
            _labelText = labelText;
        }

        public override IWebElement FindElement(ISearchContext context)
        {            
            var label = context.TryFindElement(XPath(".//label[text()='{0}']".FormatString(_labelText)), false);
            if (label ==  null) return new ByTagWithAttribute(_tagName, _attributeName ,_labelText).FindElement(context);

            var forText = label.GetAttribute("for");
            return context.FindElement(Id(forText));
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var labels = context.TryFindElements(XPath(".//label[text()='{0}']".FormatString(_labelText)), false);
            if (!labels.Any()) return new ByTagWithAttribute(_tagName, _attributeName, _labelText).FindElements(context);

            var xPathIds = labels.SelectToList(x => "@id='{0}'".FormatString(x.GetAttribute("for"))).FlattenToString("|");
            return context.FindElements(XPath(".//*[{0}]".FormatString(xPathIds)));
        }
    }
}
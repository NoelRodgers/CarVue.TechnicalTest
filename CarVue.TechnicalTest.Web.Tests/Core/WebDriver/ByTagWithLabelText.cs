using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByTagWithLabelText : By
    {
        private readonly string _tabName;
        private readonly string _labelText;

        public ByTagWithLabelText(string tabName, string labelText)
        {
            _tabName = tabName;
            _labelText = labelText;
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            var label = context.FindElement(XPath(".//label[text()='{0}']".FormatString(_labelText)));
            var forText = label.GetAttribute("for");
            return context.FindElement(Id(forText));
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var labels = context.FindElements(XPath(".//label[text()='{0}']".FormatString(_labelText)));
            var xPathIds = labels.SelectToList(x => "@id='{0}'".FormatString(x.GetAttribute("for"))).FlattenToString("|");
            return context.FindElements(XPath(".//{0}[{1}]".FormatString(_tabName, xPathIds)));
        }
    }
}
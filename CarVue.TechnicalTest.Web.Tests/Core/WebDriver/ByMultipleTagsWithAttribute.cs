using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByMultipleTagsWithAttribute : By
    {
        private readonly List<string> _tags;
        private readonly string _attributeName;
        private readonly string _attributeText;

        public ByMultipleTagsWithAttribute(string attributeName, string attributeText, params string[] tags)
        {
            _tags = tags.ToList();
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
            return XPath(".//*[{0}][{1}]".FormatString(_tags.SelectToList(BuildTagSelector).FlattenToString(" or "), BuildAttributeSelector()));
        }

        private string BuildTagSelector(string tag)
        {
            return "self::{0}".FormatString(tag);
        }
    }
}
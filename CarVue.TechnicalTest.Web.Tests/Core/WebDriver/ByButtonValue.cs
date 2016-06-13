using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByInputButtonValue : By
    {
        private readonly string _buttonValue;

        public ByInputButtonValue(string buttonValue)
        {
            _buttonValue = buttonValue;
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElement(XPath(".//input[@type='submit'|@type='button'][@value='{0}']".FormatString(_buttonValue)));                                                                         
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return context.FindElements(XPath(".//input[@type='submit'|@type='button'][@value='{0}']".FormatString(_buttonValue)));            
        }
    }
}
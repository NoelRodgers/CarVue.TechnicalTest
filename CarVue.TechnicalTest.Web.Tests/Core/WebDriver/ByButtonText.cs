using System.Collections.ObjectModel;
using CarVue.TechnicalTest.Common.Extensions;
using OpenQA.Selenium;

namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByButtonText : By
    {
        private readonly string _buttonText;

        public ByButtonText(string buttonText)
        {
            _buttonText = buttonText;
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElement(XPath(".//button[text()='{0}'] | //input[@type='submit'][@value='{0}']".FormatString(_buttonText)));                                                                         
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return context.FindElements(XPath(".//button[text()='{0}'] | //input[@type='submit'][@value='{0}']".FormatString(_buttonText)));            
        }
    }
}
namespace CarVue.TechnicalTest.Web.Tests.Core.WebDriver
{
    public class ByExtensions
    {
        private const string _specflowIdSelector = "data-specflow-id";

        public static ByLabelText LabelText(string labelText)
        {
            return new ByLabelText(labelText);
        }

        public static ByTagWithLabelTextOrAttribute TagWithLabelTextOrSpecflowDataAttribute(string tagName, string labelTextOrAttributeValue)
        {
            return new ByTagWithLabelTextOrAttribute(tagName, _specflowIdSelector, labelTextOrAttributeValue);
        }

        public static ByTagWithLabelText TagWithLabelText(string tagName, string labelText)
        {
            return new ByTagWithLabelText(tagName, labelText);
        }
        
        public static ByInputButtonValue InputButtonValue(string buttonValue)
        {
            return new ByInputButtonValue(buttonValue);
        }

        public static ByButtonText ButtonText(string buttonText)
        {
            return new ByButtonText(buttonText);
        }

        public static ByAttribute Attribute(string attributeName, string attributeText)
        {
            return new ByAttribute(attributeName, attributeText);
        }

        public static ByTagWithAttribute TagAndAttribute(string tagName, string attributeName, string attributeText)
        {
            return new ByTagWithAttribute(tagName, attributeName, attributeText);
        }

        public static ByTagWithContent TagWithContent(string tagName, string contentText)
        {
            return new ByTagWithContent(tagName, contentText);
        }

        public static ByAttribute SpecflowDataAttribute(string attributeText)
        {
            return new ByAttribute(_specflowIdSelector, attributeText);
        }

        public static ByTagWithAttribute TagAndSpecflowDataAttribute(string tagName, string attributeText)
        {
            return new ByTagWithAttribute(tagName, _specflowIdSelector, attributeText);
        }

        public static ByMultipleTagsWithAttribute SectionOrDivWithSpecflowDataAttribute(string attributeText)
        {
            return new ByMultipleTagsWithAttribute(_specflowIdSelector, attributeText, "div", "section");
        }
    }
}
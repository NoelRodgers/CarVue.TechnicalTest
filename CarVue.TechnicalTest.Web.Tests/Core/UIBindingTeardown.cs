using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Web.Tests.Core.Settings;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CarVue.TechnicalTest.Web.Tests.Core
{
    [Binding]
    public class UIBindingTeardown
    {
        private static SpecflowSettings _settings;
        

        [BeforeTestRun]
        public static void Setup()
        {           
            UIContainer.BootstrapContainer();
            _settings = UIContainer.GetInstance<IConfigurationBuilder>()
                                   .GetConfiguration<SpecflowSettings>();

            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _settings.ScreenshotFolder);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            Directory.GetFiles(folderPath).ToList().ForEach(File.Delete);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            UIEnvironment.DisposeWebDriver();
        }

        [AfterScenario]
        public static void ScreenshotIfErrored()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                var featureTitle = FeatureContext.Current.FeatureInfo.Title;
                var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;

                var screenshot = UIEnvironment.WebDriverAs<ITakesScreenshot>().GetScreenshot();
                screenshot.SaveAsFile(GetScreenshotPath(featureTitle, scenarioTitle), ImageFormat.Png);
            }
            UIEnvironment.WebDriver
                         .Manage()
                         .Cookies
                         .DeleteAllCookies();
        }


        private static string GetScreenshotPath(string featureTitle, string scenarioTitle)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _settings.ScreenshotFolder, "{0} - {1}.png".FormatString(featureTitle, scenarioTitle));
        }        
    }
}
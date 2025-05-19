using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Gherkin.Model;
using eTicketBangladesh_Railway.Helper;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using UMS.UI.Test.ERP.TestFiles.Support;
using Xunit.Abstractions;

namespace eTicketBangladesh_Railway.Test_Files.Hooks
{
    [Binding]
    public sealed class Hooks(IObjectContainer container, ITestOutputHelper testOutput) : ExtentReport
    {
        private IWebDriver _driver = null!;
        private readonly IObjectContainer _container = container;
        private readonly ITestOutputHelper _testOutput = testOutput;
        private readonly IConfiguration _configuration = AppHelper.GetAppSettings();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Before test run..");
            DeployExtentReport();
            //SqLiteDbService.SqLiteSchemaDbVerify();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Before feature..");
            _feature = _reports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void CreateWebDriver(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Before scenario..");
            var downloadPath = AppHelper.GetFolderPath("Test Files\\Reports");

            var chromeOptions = new ChromeOptions();
            {
                if (Convert.ToBoolean(_configuration["Settings:IsHeadless"]))
                {
                    chromeOptions.AddArgument("--headless");             // Run in headless mode
                }
                chromeOptions.AddArgument("--window-size=1080,720");     // Set window size to 1920x1080
                chromeOptions.AddArgument("--no-sandbox");              // Overcome limited resource problems
                chromeOptions.AddArgument("--disable-dev-shm-usage");   // Overcome limited resource problems
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            }
            _driver = new ChromeDriver(chromeOptions);
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(_configuration["Settings:BaseUrl"]);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            _ = new LoginHook(_driver, scenarioContext.ScenarioInfo);

            // Make this instance available to all other step definitions
            _container.RegisterInstanceAs(_driver, null, true);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Thread.Sleep(200);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            // When step pass
            var stepNode = _scenario.CreateNode(new GherkinKeyword(stepType), stepName);

            // When step fail
            if (scenarioContext.TestError != null && stepNode != null)
            {
                _testOutput.WriteLine($"{stepName} :: {scenarioContext.TestError.Message}");
                stepNode.Fail(scenarioContext.TestError.Message, MediaEntityBuilder
                    .CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After scenario..");
            _driver = _container.Resolve<IWebDriver>();
            _driver.Dispose();
            //driver.Close();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After feature..");
            DisposeExtentReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("After testrun..");
        }
    }
}
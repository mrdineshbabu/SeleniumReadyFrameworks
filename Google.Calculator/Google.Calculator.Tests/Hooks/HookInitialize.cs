using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Google.Calculator.Framework;
using Microsoft.Extensions.Configuration;
using Google.Calculator.Framework.BaseClass;

namespace Google.Calculator.Tests.Hooks
{
    [Binding]
    public sealed class HookInitialize
    {
        private DriverHelper _driverHelper;

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName = null;
        private static ExtentTest featureName;
        private static ExtentReports extent;
        
        public static string resultFolder = null;
        public static TestConfig _config = new TestConfig();
        private static TestBase _testBase;        
                
        public HookInitialize(DriverHelper driverHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void BeforeFeature(DriverHelper driverHelper, FeatureContext _featureContext)
        {
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            {
                var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
                
                if (_scenarioContext.TestError == null)
                {
                    if (stepType == "Given")
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    else if (stepType == "When")
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    else if (stepType == "Then")
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    else if (stepType == "And")
                        _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                }

                else if (_scenarioContext.TestError != null)
                {
                    var mediaEntity = CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim()).Build();
                    if (stepType == "Given")
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                    else if (stepType == "When")
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                    else if (stepType == "Then")
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                }
                
                else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                {
                    if (stepType == "Given")
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    else if (stepType == "When")
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    else if (stepType == "Then")
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                }
            }
        }

        public MediaEntityBuilder CaptureScreenshotAndReturnModel(string name)
        {
            var screenshot = ((ITakesScreenshot)_driverHelper.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name);
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {                    
            var configuration = Configure();
            _config.APP_URL = configuration["APP_URL"];
            TestBase.getAPPURL = _config.APP_URL;

            _config.Report_Path = configuration["ReportPath"];
            TestBase.getReportPath = _config.Report_Path;
            resultFolder = TestBase.getReportPath + @"\Automation Test Results_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            if (!Directory.Exists(resultFolder + @"\"))
            {
                Directory.CreateDirectory(resultFolder + @"\");
            }
            var htmlReporter = new ExtentSparkReporter(resultFolder + @"\GoogleCalculatorTestReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "GoogleCalculatorTestReport";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);            
        }

        private static IConfiguration Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true);
            return builder.Build();
        }

        [BeforeScenario]
        public void Initalize(ScenarioContext _scenarioContext, DriverHelper driverHelper)
        {
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            _testBase = new TestBase(driverHelper);            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
            Console.WriteLine("Completed Execution");
        }

        [AfterTestRun]
        public static void EndOfTestExecution()
        {
            extent.Flush();
        }
    }
}
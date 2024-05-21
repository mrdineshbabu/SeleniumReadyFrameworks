using Google.Calculator.Framework;
using Google.Calculator.Tests.Pages;
using TechTalk.SpecFlow;

namespace Google.Calculator.Tests.Steps
{
    [Binding]
    public class CommanSteps
    {
        private DriverHelper _driverHelper;
        CalculatorPage _calculatorPage;

        public CommanSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _calculatorPage = new CalculatorPage(driverHelper);
        }

        [Given(@"User launch the google calculator url")]
        public void GivenUserLaunchTheGoogleCalculatorUrl()
        {
            _calculatorPage.LaunchURL();
        }

        [When(@"User press (.*)")]
        public void WhenUserPress(string p0)
        {
            _calculatorPage.Click(p0);
        }

        [Then(@"User should see (.*) in the result textbox")]
        public void ThenUserShouldSeeInTheResultTextbox(string p0)
        {
            _calculatorPage.VerifyResult(p0);
        }        
    }
}
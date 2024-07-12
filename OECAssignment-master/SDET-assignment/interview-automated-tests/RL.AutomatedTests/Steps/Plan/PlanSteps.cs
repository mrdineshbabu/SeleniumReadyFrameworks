using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace RL.AutomatedTests.Steps.Plan;

[Binding]
public class PlanSteps
{
    private readonly ScenarioContext _context;
    private readonly string _urlBase = "http://localhost:3001";
    private readonly TimeSpan _waitDurration = new(0, 0, 1);
    private string? procedure = null;

    public PlanSteps(ScenarioContext context)
    {
        _context = context;
    }

    [Given("I'm on the start page")]
    public async Task ImOnTheStartPage()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.Navigate().GoToUrl(_urlBase);
        var wait = new WebDriverWait(driver, _waitDurration);
        wait.Until(ExpectedConditions.UrlContains(_urlBase));
    }

    [When("I click on start")]
    public async Task IClickOnStart()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.FindElement(By.Id("start")).Click();
        var wait = new WebDriverWait(driver, _waitDurration);
        wait.Until(ExpectedConditions.UrlMatches(_urlBase + "/plan"));
    }

    [Then("I'm on the plan page")]
    public async Task ImOnThePlanPage()
    {
        var driver = _context.Get<IWebDriver>("driver");
        var wait = new WebDriverWait(driver, _waitDurration);
        wait.Until(ExpectedConditions.UrlMatches(@"/plan/(\d+)"));
        Thread.Sleep(10000);
        driver.Url.Should().MatchRegex(@"/plan/(\d+)");
    }

    [When("I click on the checkbox a procedure")]
    public async Task WhenIClickOnTheCheckboxAProcedure()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.FindElements(By.ClassName("form-check"))[0].FindElement(By.Id("procedureCheckbox")).Click();
        procedure = driver.FindElements(By.ClassName("form-check"))[0].Text;
        Thread.Sleep(2000);
    }

    [Then("I should see the selected procedure under the added to plan section")]
    public async Task ThenIShouldSeeTheSelectedProcedureUnderTheAddedToPlanSection()
    {
        var driver = _context.Get<IWebDriver>("driver");
        if (!driver.FindElements(By.ClassName("col"))[2].Text.Contains(procedure))
        {
            Assert.Fail("Selected procedure is not added to the plan");
        }
    }

    [When("I assign the procedure to a user")]
    public async Task WhenIAssignTheProcedureToAUser()
    {
        var driver = _context.Get<IWebDriver>("driver");
        Thread.Sleep(4000);
        driver.FindElement(By.CssSelector("[class=' css-qbdosj-Input']")).Click();
        Thread.Sleep(4000);
        new Actions(driver)
                .SendKeys(Keys.Tab)
                .Perform();
        Thread.Sleep(2000);
    }

    [Then("I should see the assigned user name in the user section")]
    public async Task ThenIShouldSeeTheAssignedUserNameInTheUserSection()
    {
        var driver = _context.Get<IWebDriver>("driver");
        if (!driver.FindElements(By.ClassName("col"))[2].Text.Contains("Nick Morrison"))
        {
            Assert.Fail("Selected user is not assigned to the plan");
        }
    }

    [When("I refresh the page")]
    public async Task WhenIRefreshThePage()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.Navigate().Refresh();
        Thread.Sleep(3000);
    }

    [Then("I should see the assigned user name in the user section after refresh")]
    public async Task ThenIShouldSeeTheAssignedUserNameInTheUserSectionAfterRefresh()
    {
        var driver = _context.Get<IWebDriver>("driver");
        if (!driver.FindElements(By.ClassName("col"))[2].Text.Contains("Nick Morrison"))
        {
            Assert.Fail("Selected user is not assigned to the plan after refresh");
        }
    }

}
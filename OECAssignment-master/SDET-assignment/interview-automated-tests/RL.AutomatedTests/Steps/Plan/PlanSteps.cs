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
    private string? assignee = null;

    public PlanSteps(ScenarioContext context)
    {
        _context = context;
    }

    [Given("I'm on the start page")]
    public async Task ImOnTheStartPage()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.Navigate().GoToUrl(_urlBase);
        driver.Manage().Window.Maximize();
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

    [When(@"I click on the procedure ""([^""]*)""")]
    public void WhenIClickOnTheProcedure(string p0)
    {
        var driver = _context.Get<IWebDriver>("driver");
        var wait = new WebDriverWait(driver, _waitDurration);
        
        procedure = p0;
        int procedureCount = driver.FindElements(By.ClassName("col"))[1].FindElements(By.ClassName("py-2")).Count();
        for (int i = 0; i < procedureCount; i++) 
        {
            if (driver.FindElements(By.ClassName("col"))[1].FindElements(By.ClassName("py-2"))[i].Text.Equals(procedure))
            {
                driver.FindElements(By.ClassName("col"))[1].FindElements(By.ClassName("py-2"))[i].FindElement(By.ClassName("form-check")).FindElement(By.Id("procedureCheckbox")).Click();
                break;
            }
        }
        wait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElements(By.ClassName("col"))[2], procedure));        
    }

    [When(@"I assign the procedure ""([^""]*)"" to ""([^""]*)""")]
    public void WhenIAssignTheProcedureTo(string p0, string p1)
    {
        var driver = _context.Get<IWebDriver>("driver");
        var wait = new WebDriverWait(driver, _waitDurration);

        procedure = p0;
        assignee = p1;
        int procedureCount = driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2")).Count();
        for(int i = 0;i < procedureCount; i++)
        {
            if (driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].Text.Contains(procedure))
            {
                driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].FindElements(By.TagName("div"))[1].Click();
                int assigneeCount = driver.FindElement(By.CssSelector("[class=' css-1nmdiq5-menu']")).FindElements(By.TagName("div")).Count();
                for (int j = 1; j < assigneeCount; j++)
                {
                    if (driver.FindElement(By.CssSelector("[class=' css-1nmdiq5-menu']")).FindElements(By.TagName("div"))[j].Text.Contains(assignee))
                    {
                        driver.FindElement(By.CssSelector("[class=' css-1nmdiq5-menu']")).FindElements(By.TagName("div"))[j].Click();
                        break;
                    }
                }
                break;
            }
        }
        wait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElements(By.ClassName("col"))[2], assignee));
    }

    [Then(@"I should see ""([^""]*)"" under the procedure ""([^""]*)""")]
    public void ThenIShouldSeeUnderTheProcedure(string p0, string p1)
    {
        var driver = _context.Get<IWebDriver>("driver");
        procedure = p1;
        assignee = p0;
        int procedureCount = driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2")).Count();
        for (int i = 0; i < procedureCount; i++)
        {
            if (driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].Text.Contains(procedure))
            {
                if (!driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].Text.Contains(assignee))
                {
                    Assert.Fail("Selected user is not assigned to the procedure");
                }                
                break;
            }
        }
    }

    [Then(@"I should see ""([^""]*)"" under the procedure ""([^""]*)"" after refresh")]
    public void ThenIShouldSeeUnderTheProcedureAfterRefresh(string p0, string p1)
    {
        var driver = _context.Get<IWebDriver>("driver");
        procedure = p1;
        assignee = p0;
        int procedureCount = driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2")).Count();
        for (int i = 0; i < procedureCount; i++)
        {
            if (driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].Text.Contains(procedure))
            {
                if (!driver.FindElements(By.ClassName("col"))[2].FindElements(By.ClassName("py-2"))[i].Text.Contains(assignee))
                {
                    Assert.Fail("Selected user is not assigned to the procedure after refresh");
                }
                break;
            }
        }
    }


    [Then(@"I should see the selected procedure under the added to plan section")]
    public void ThenIShouldSeeTheSelectedProcedureUnderTheAddedToPlanSection()
    {
        var driver = _context.Get<IWebDriver>("driver");
        if (!driver.FindElements(By.ClassName("col"))[2].Text.Contains(procedure))
        {
            Assert.Fail("Selected procedure is not added to the plan");
        }        
    }

    [When(@"I refresh the page")]
    public void WhenIRefreshThePage()
    {
        var driver = _context.Get<IWebDriver>("driver");
        driver.Navigate().Refresh();
        var wait = new WebDriverWait(driver, _waitDurration);
        wait.Until(ExpectedConditions.UrlMatches(@"/plan/(\d+)"));
    }
}
using Google.Calculator.Framework.BaseClass;
using Google.Calculator.Framework.Helper;
using Google.Calculator.Framework;
using OpenQA.Selenium;
using System.Data;

namespace Google.Calculator.Tests.Pages
{
    public class CalculatorPage
    {
        private DriverHelper _driverHelper;
        CommanMethods _commanMethods;

        public CalculatorPage(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _commanMethods = new CommanMethods(driverHelper);
        }

        public IWebElement Number0 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='0']"));
        public IWebElement Number1 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='1']"));
        public IWebElement Number2 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='2']"));
        public IWebElement Number3 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='3']"));
        public IWebElement Number4 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='4']"));
        public IWebElement Number5 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='5']"));
        public IWebElement Number6 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='6']"));
        public IWebElement Number7 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='7']"));
        public IWebElement Number8 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='8']"));
        public IWebElement Number9 => _driverHelper.Driver.FindElement(By.XPath("//div[text()='9']"));
        public IWebElement Plus => _driverHelper.Driver.FindElement(By.XPath("//div[text()='+']"));
        public IWebElement Minus => _driverHelper.Driver.FindElement(By.XPath("//div[text()='−']"));
        public IWebElement Multiply => _driverHelper.Driver.FindElement(By.XPath("//div[text()='×']"));
        public IWebElement Divide => _driverHelper.Driver.FindElement(By.XPath("//div[text()='÷']"));
        public IWebElement Equal => _driverHelper.Driver.FindElement(By.XPath("//div[text()='=']"));
        public IWebElement Dot => _driverHelper.Driver.FindElement(By.XPath("//td//div[text()='.']"));
        public IWebElement Result => _driverHelper.Driver.FindElement(By.XPath("//span[@id='cwos']"));
        public IWebElement AC => _driverHelper.Driver.FindElement(By.XPath("//td//div[text()='AC']"));
        public IWebElement CE => _driverHelper.Driver.FindElement(By.XPath("//td//div[text()='CE']"));

        public void LaunchURL()
        {
            _driverHelper.Driver.Manage().Window.Maximize();
            _driverHelper.Driver.Navigate().GoToUrl(TestBase.getAPPURL);
        }

        public void Click(string key)
        {
            switch (key)
            {
                case "\"0\"":
                    Number0.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"1\"":
                    Number1.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"2\"":
                    Number2.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"3\"":
                    Number3.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"4\"":
                    Number4.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"5\"":
                    Number5.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"6\"":
                    Number6.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"7\"":
                    Number7.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"8\"":
                    Number8.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"9\"":
                    Number9.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"+\"":
                    Plus.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"-\"":
                    Minus.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"×\"":
                    Multiply.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"÷\"":
                    Divide.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"=\"":
                    Equal.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\".\"":
                    Dot.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"AC\"":
                    AC.Click();
                    _commanMethods.Wait(1);
                    break;
                case "\"CE\"":
                    CE.Click();
                    _commanMethods.Wait(1);
                    break;
            }
        }

        public void VerifyResult(string key)
        {
            switch (key)
            {
                case "\"0\"":
                    NumbersResultShown(key);                    
                    break;
                case "\"1\"":
                    NumbersResultShown(key);
                    break;
                case "\"2\"":
                    NumbersResultShown(key);
                    break;
                case "\"3\"":
                    NumbersResultShown(key);
                    break;
                case "\"4\"":
                    NumbersResultShown(key);
                    break;
                case "\"5\"":
                    NumbersResultShown(key);
                    break;
                case "\"6\"":
                    NumbersResultShown(key);
                    break;
                case "\"7\"":
                    NumbersResultShown(key);
                    break;
                case "\"8\"":
                    NumbersResultShown(key);
                    break;
                case "\"9\"":
                    NumbersResultShown(key);
                    break;
                case "\"+\"":
                    SymbolsResultShown(key);
                    break;
                case "\"-\"":
                    SymbolsResultShown(key);
                    break;
                case "\"×\"":
                    SymbolsResultShown(key);
                    break;
                case "\"÷\"":
                    SymbolsResultShown(key);
                    break;
                case "\".\"":
                    SymbolsResultShown(key);
                    break;
            }
        }

        public void NumbersResultShown(string key)
        {
            string result = "\"" + Result.Text + "\"";
            if (!result.Equals(key))
            {
                Assert.Fail("Expected result is " + key + ". But actual result is " + result + ".");
            }
        }

        public void SymbolsResultShown(string key)
        {
            key = key.Replace("\"", "");
            string result = Result.Text;
            if (!result.Contains(key))
            {
                Assert.Fail("Expected result is " + key + ". But actual result is " + result + ".");
            }
        }        
    }
}
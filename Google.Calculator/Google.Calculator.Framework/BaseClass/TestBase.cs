using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Google.Calculator.Framework.BaseClass
{
    public class TestBase
    {
        private DriverHelper _driverHelper;

        public TestBase(DriverHelper driverHelper) 
        {
            _driverHelper = driverHelper;
            DriverSetUp();
        }

        public static string getEnvironment;
        public static string getAPPURL;
        public static string getReportPath;

        private void DriverSetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");
            _driverHelper.Driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }
    }
}

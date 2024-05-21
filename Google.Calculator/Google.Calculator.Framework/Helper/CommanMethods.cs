using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace Google.Calculator.Framework.Helper
{
    public class CommanMethods
    {
        private DriverHelper _driverHelper;

        public CommanMethods(DriverHelper driverHelper) 
        { 
            _driverHelper = driverHelper;
        }
                
        public void Wait(int time)
        {
            Thread.Sleep(time * 1000);
        }        
    }
}

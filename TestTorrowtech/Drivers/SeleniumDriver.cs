using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestTorrowtech.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver Driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext _scenarioContext)
        {
            this._scenarioContext = _scenarioContext;
        }

        public IWebDriver Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            Driver = new ChromeDriver(options);

            _scenarioContext.Set(Driver, "WebDriver");

            return Driver;
        }
    }
}

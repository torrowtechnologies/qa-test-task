using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestTorrowtech.Drivers;

namespace TestTorrowtech.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext _scenarioContext)
        {
            this._scenarioContext = _scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver driver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(driver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}

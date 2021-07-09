using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestTorrowtech.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        TimeSpan WaitTimeout = TimeSpan.FromSeconds(10);

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            Check(driver);
        }

        public bool IsElementPresent(By element)
        {
            return Driver.FindElement(element).Displayed;
        }

        public bool IsElementMiss(By element)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            if (Driver.FindElements(element).Count != 0)
            {
                Driver.Manage().Timeouts().ImplicitWait = WaitTimeout;
                return false;
            }
            Driver.Manage().Timeouts().ImplicitWait = WaitTimeout;
            return true;
        }

        public abstract void Check(IWebDriver driver);

        public void AssertLocator(IWebDriver driver, By xpath)
        {
            Assert.IsTrue(new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                        .Until(drv => IsElementPresent(xpath)), "Element not found");
        }
    }
}

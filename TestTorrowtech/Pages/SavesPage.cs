using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTorrowtech.Pages
{
    public class SavesPage : BasePage
    {
        private readonly By ContextList = By.XPath("//*[contains(@qa-id, 'context-list-page')]");
        private readonly By TabBar = By.XPath("//*[contains(@qa-id, 'tab-bar')]");

        public SavesPage(IWebDriver driver) : base(driver) { }

        public override void Check(IWebDriver driver)
        {
            AssertLocator(driver, ContextList);
            AssertLocator(driver, TabBar);
        }
    }
}

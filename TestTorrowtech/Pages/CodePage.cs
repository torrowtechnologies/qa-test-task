using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTorrowtech.Pages
{
    public class CodePage : BasePage
    {
        private readonly By AuthPhoneCodePage = By.XPath("//*[contains(@qa-id, 'auth-phone-code-page')]");
        private readonly By WarningWrongCode = By.XPath("//*[contains(@qa-id, 'auth-code-warning')]");

        private string NumberOnKeyboard = "//*[contains(@qa-id, 'keyboard-button')]/*[text() = '{0}']";
        public CodePage(IWebDriver driver) : base(driver) { }

        public void WriteNumber(string number)
        {
            Console.WriteLine(number);
            for (int i = 0; i < number.Length; i++)
            {
                Thread.Sleep(500);
                Driver.FindElement(By.XPath(String.Format(NumberOnKeyboard, number[i]))).Click();
            }
        }

        public SavesPage WriteRightCode(string code)
        {
            WriteNumber(code);
            return new SavesPage(Driver);
        }

        public CodePage AssertWarning()
        {
            AssertLocator(Driver, WarningWrongCode);
            return this;
        }

        public override void Check(IWebDriver driver)
        {
            AssertLocator(driver, AuthPhoneCodePage);
        }
    }
}

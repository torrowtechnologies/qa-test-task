using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTorrowtech.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By InputNumberField = By.XPath("//*[contains(@qa-id, 'auth-phone-input')]");
        private readonly By Keyboard = By.XPath("//*[contains(@exclude, '.phone-input-wrapper')]");
        private readonly By SubmitButton = By.XPath("//button[contains(@qa-id, 'auth-phone-submit')]");
        private readonly By SignInTorrowButton = By.XPath("//ion-button[contains(@class, 'login-btn')]");
        private readonly By LangChangeTrigger = By.XPath("//*[contains(@class, 'secondary-button-slot-end')]//button[contains(@qa-id, 'lang-change-trigger')]");
        private readonly By ChangeRuLang = By.XPath("//*[contains(@qa-id, 'lang-change-select-ru')]");
        private readonly By ChangeEnLang = By.XPath("//*[contains(@qa-id, 'lang-change-select-en')]");
        private readonly By AuthPhonePage = By.XPath("//*[contains(@qa-id, 'auth-phone-page')]");

        private string numberOnKeyboard = "//*[contains(@qa-id, 'keyboard-button')]/*[text() = '{0}']";

        public LoginPage SignIn()
        {
            Driver.FindElement(SignInTorrowButton).Click();
            return new LoginPage(Driver);
        }

        public LoginPage ChangeLanguageRu()
        {
            Driver.FindElement(LangChangeTrigger).Click();
            Driver.FindElement(ChangeRuLang).Click();
            return this;
        }

        public LoginPage ChangeLanguageEn()
        {
            Driver.FindElement(LangChangeTrigger).Click();
            Driver.FindElement(ChangeEnLang).Click();
            return this;
        }

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage showKeyboard()
        {
            Driver.FindElement(InputNumberField).Click();
            AssertLocator(Driver, Keyboard);
            Thread.Sleep(1000);
            return this;
        }

        public LoginPage WriteNumber(string number)
        {
            Console.WriteLine(number);
            for (int i = 0; i < number.Length; i++)
            {
                Thread.Sleep(300);
                Driver.FindElement(By.XPath(String.Format(numberOnKeyboard, number[i]))).Click();
            }
            return this;
        }

        public LoginPage SubmitNumber()
        {
            Driver.FindElement(SubmitButton).Click();
            return this;
        }

        public override void Check(IWebDriver driver)
        {
            AssertLocator(driver, AuthPhonePage);
        }
    }
}

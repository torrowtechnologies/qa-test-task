using OpenQA.Selenium;
using System.Linq;
using System.Text.RegularExpressions;

namespace TorrowTechTest.PageObjects
{
    class AuthPageObject
    {
        private const string AuthPhoneUrl = "https://dev1.torrow.net/app/login/auth/phone/number";
        private const string PhoneUrl = "https://smsdev1.torrow.net/api/phone/79818947635";
        private const string EmailUrl = "https://emaildev1.torrow.net/api/email/rozovvi1@gmail.com";

        private readonly IWebDriver _webDriver;

        public const int DefaultWaitInSeconds = 5;

        public AuthPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Url = AuthPhoneUrl;
        }
        
        private IWebElement EnterForPhoneButton => _webDriver.FindElement(By.TagName("ion-button"));
        private IWebElement NumberInput => _webDriver.FindElement(By.ClassName("phone-input-label"));
        private IWebElement AuthPhoneSubmitButton => _webDriver.FindElement(By.ClassName("submit-button"));
        private IWebElement WarningTextMessage => _webDriver.FindElement(By.ClassName("warning-text"));
        private IWebElement WarningMessage => _webDriver.FindElement(By.ClassName("warning"));
        private IWebElement EmailLink => _webDriver.FindElement(By.ClassName("use-email-ref"));
        private IWebElement AuthEmailInput => _webDriver.FindElement(By.TagName("input"));
        private IWebElement AuthEmailSubmitButton => _webDriver.FindElement(By.TagName("button"));
        private IWebElement WarningMessageFromEmail => _webDriver.FindElement(By.ClassName("warning-text"));
        private IWebElement KeyBoardsNumbersButton0 => _webDriver.FindElement(By.XPath("//ion-row[4]/ion-col[2]/button"));
        private IWebElement KeyBoardsNumbersButton1 => _webDriver.FindElement(By.XPath("//ion-row[1]/ion-col[1]/button"));
        private IWebElement KeyBoardsNumbersButton2 => _webDriver.FindElement(By.XPath("//ion-row[1]/ion-col[2]/button"));
        private IWebElement KeyBoardsNumbersButton3 => _webDriver.FindElement(By.XPath("//ion-row[1]/ion-col[3]/button"));
        private IWebElement KeyBoardsNumbersButton4 => _webDriver.FindElement(By.XPath("//ion-row[2]/ion-col[1]/button"));
        private IWebElement KeyBoardsNumbersButton5 => _webDriver.FindElement(By.XPath("//ion-row[2]/ion-col[2]/button"));
        private IWebElement KeyBoardsNumbersButton6 => _webDriver.FindElement(By.XPath("//ion-row[2]/ion-col[3]/button"));
        private IWebElement KeyBoardsNumbersButton7 => _webDriver.FindElement(By.XPath("//ion-row[3]/ion-col[1]/button"));
        private IWebElement KeyBoardsNumbersButton8 => _webDriver.FindElement(By.XPath("//ion-row[3]/ion-col[2]/button"));
        private IWebElement KeyBoardsNumbersButton9 => _webDriver.FindElement(By.XPath("//ion-row[3]/ion-col[3]/button"));
        private IWebElement FlagForLanguage => _webDriver.FindElement(By.CssSelector(".lang-change:nth-child(1) .trigger-flag"));
        private IWebElement RusLang => _webDriver.FindElement(By.XPath("//tt-lang-option[@name='Русский']"));
        private IWebElement EnLang => _webDriver.FindElement(By.XPath("//tt-lang-option[@name='English']"));
        public void ClickEnterButton()
        {
            EnterForPhoneButton.Click();
        }

        public void ClickInputPhone()
        {
            NumberInput.Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void ClickSubmitButton()
        {
            AuthPhoneSubmitButton.Click();
        }

        public string WarningTextMessageText()
        {
            return WarningTextMessage.Text;
        }

        public string WarningMessageText()
        {
            return WarningMessage.Text;
        }

        public void ClickEmailLink()
        {
            EmailLink.Click();
        }

        public void InputEmail(string email)
        {
            AuthEmailInput.Clear();
            AuthEmailInput.SendKeys(email);
        }

        public void ClickSubmitEmailButton()
        {
            AuthEmailSubmitButton.Click();
        }

        public string WarningMessageFromEmailText()
        {
            return WarningMessageFromEmail.Text;
        }

        public void ClickNumbers(string numbers)
        {

            int[] numbercode = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbercode[i] = int.Parse(numbers[i].ToString());
            }

            foreach (int number in numbercode)
            {
                switch (number)
                {
                    case 0:
                        KeyBoardsNumbersButton0.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 1:
                        KeyBoardsNumbersButton1.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 2:
                        KeyBoardsNumbersButton2.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 3:
                        KeyBoardsNumbersButton3.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 4:
                        KeyBoardsNumbersButton4.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 5:
                        KeyBoardsNumbersButton5.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 6:
                        KeyBoardsNumbersButton6.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 7:
                        KeyBoardsNumbersButton7.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 8:
                        KeyBoardsNumbersButton8.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 9:
                        KeyBoardsNumbersButton9.Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        public string OpenTabWithPhoneCodeAndGetIt()
        {
            System.Threading.Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.open();");
            System.Collections.ObjectModel.ReadOnlyCollection<string> tabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(tabs[1]);
            _webDriver.Url = PhoneUrl;
            _webDriver.Navigate().Refresh();
            string msg = _webDriver.FindElement(By.TagName("pre")).Text;
            string resultString = string.Join(string.Empty, Regex.Matches(msg, @"\d+").OfType<Match>().Select(m => m.Value));
            int.TryParse(resultString, out int code);
            _webDriver.SwitchTo().Window(tabs[0]);
            return code.ToString();
        }
        public string OpenTabWithEmailCodeAndGetIt()
        {
            System.Threading.Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.open();");
            System.Collections.ObjectModel.ReadOnlyCollection<string> tabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(tabs[1]);
            _webDriver.Url = EmailUrl;
            _webDriver.Navigate().Refresh();
            string msg = _webDriver.FindElement(By.TagName("pre")).Text;
            string resultString = string.Join(string.Empty, Regex.Matches(msg, @"\d+").OfType<Match>().Select(m => m.Value));
            int.TryParse(resultString, out int code);
            _webDriver.SwitchTo().Window(tabs[0]);
            return code.ToString();
        }

        public void ChangeLangRus()
        {
            FlagForLanguage.Click();
            RusLang.Click();
        }

        public void ChangeLangEng()
        {
            FlagForLanguage.Click();
            EnLang.Click();
        }


    }
}

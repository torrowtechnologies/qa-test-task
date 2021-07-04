using System;
using TechTalk.SpecFlow;
using TorrowTechTest.Drivers;
using TorrowTechTest.PageObjects;

namespace TorrowTechTest.Steps
{


    [Binding]
    public class AuthTestsSteps
    {
        private readonly WebDriver driver;
        private readonly AuthPageObject authPageObject;
        private string code;

        public AuthTestsSteps(WebDriver browserDriver)
        {
            driver = browserDriver;
            authPageObject = new AuthPageObject(driver.Current);
            driver.Current.Manage().Window.Maximize();
        }

        [Given(@"click on enter")]
        public void GivenClickOnEnter()
        {
            System.Threading.Thread.Sleep(5 * 1000);
            authPageObject.ClickEnterButton();
        }

        [Given(@"change langugae")]
        public void GivenChangelanguage()
        {
           authPageObject.ChangeLangEng();
        }

        [Then(@"click on enter")]
        public void ThenClickOnEnter()
        {
            System.Threading.Thread.Sleep(5 * 1000);
            authPageObject.ClickEnterButton();
        }

        [Then(@"click email link")]
        public void ThenClickEmailLink()
        {
            System.Threading.Thread.Sleep(2 * 1000);
            authPageObject.ClickEmailLink();
            System.Threading.Thread.Sleep(2 * 1000);

        }

        [Then(@"input phone number")]
        public void ThenInputPhoneNumber()
        {
            authPageObject.ClickInputPhone();
            System.Threading.Thread.Sleep(2 * 1000);
            authPageObject.ClickNumbers("9818947635");
            System.Threading.Thread.Sleep(2 * 1000);
        }

        [Then(@"input wrong phone number")]
        public void ThenInputWrongPhoneNumber()
        {
            authPageObject.ClickInputPhone();
            System.Threading.Thread.Sleep(2 * 1000);
            authPageObject.ClickNumbers("555");
            System.Threading.Thread.Sleep(2 * 1000);
        }

        [Then(@"click submit button")]
        public void ThenClickSubmitButton()
        {
            authPageObject.ClickSubmitButton();
        }

        [Then(@"click submit email button")]
        public void ThenClickSubmitEmailButton()
        {
            authPageObject.ClickSubmitEmailButton();
        }

        [Then(@"open new page and get phone code")]
        public void ThenOpenNewPageAndGetPhoneCode()
        {
            code = authPageObject.OpenTabWithPhoneCodeAndGetIt();
            System.Threading.Thread.Sleep(5 * 1000);
        }

        [Then(@"open new page and get email code")]
        public void ThenOpenNewPageAndGetEmailCode()
        {
            code = authPageObject.OpenTabWithEmailCodeAndGetIt();
            System.Threading.Thread.Sleep(5 * 1000);
        }

        [Then(@"input code")]
        public void ThenInputCode()
        {
            System.Threading.Thread.Sleep(2 * 1000);
            authPageObject.ClickNumbers(code);
            System.Threading.Thread.Sleep(2 * 1000);
        }

        [Then(@"reverse code")]
        public void ThenReverseCode()
        {
            char[] wrongcode = code.ToCharArray();
            Array.Reverse(wrongcode);
            code = new string(wrongcode);
        }

        [Then(@"input wrong code")]
        public void ThenInputWrongCode()
        {
            authPageObject.ClickNumbers(code);
            System.Threading.Thread.Sleep(2 * 1000);
        }

        [Then(@"wait")]
        public void ThenWait()
        {
            System.Threading.Thread.Sleep(1000);
        }

        [Then(@"wait minute")]
        public void ThenWaitMinute()
        {
            System.Threading.Thread.Sleep(60*1000);
        }

        [Then(@"check link")]
        public void ThenCheckLink()
        {
            Console.WriteLine(driver.Current.Url);
            System.Threading.Thread.Sleep(1000);
            if (driver.Current.Url == "https://dev1.torrow.net/app/registration/user-details")
                Console.WriteLine("Good");
        }
        
        [Then(@"input email")]
        public void ThenInputEmailRozovviGamil_Com()
        {
            string email = "rozovvi1@gmail.com";
            authPageObject.InputEmail(email);
        }
        
        [Then(@"input wrong email (.*)")]
        public void ThenInputWrongEmail(string email)
        {
            authPageObject.InputEmail(email);
        }

        //Введите корректный email. Пример: support@torrowtech.com
        [Then(@"check warning message email")]
        public void ThenCheckWarningMessageEmail()
        {
            System.Threading.Thread.Sleep(1000);
            string warning = authPageObject.WarningMessageFromEmailText();
            Console.WriteLine(warning);
        }

        //Введите номер. Пример: +7 (999) 999-99-99
        [Then(@"check warning message phone")]
        public void ThenCheckWarningMessagePhone()
        {
            System.Threading.Thread.Sleep(1000);
            string warning = authPageObject.WarningMessageFromEmailText();
            Console.WriteLine(warning);
        }

        //Неверный код
        [Then(@"check warning message about code")]
        public void ThenCheckWarningMessageAboutCode()
        {
            System.Threading.Thread.Sleep(1000);
            string warning = authPageObject.WarningMessageText();
            Console.WriteLine(warning);
        }

        //Превышено число попыток ввода кода
        [Then(@"check warning message codes")]
        public void ThenCheckWarningMessageCodes()
        {
            System.Threading.Thread.Sleep(1000);
            string warning = authPageObject.WarningTextMessageText();
            Console.WriteLine(warning);
        }

        //Срок действия кода истёк
        [Then(@"check warning message code limit time")]
        public void ThenCheckWarningMessageCodeLimitTime()
        {
            System.Threading.Thread.Sleep(1000);
            string warning = authPageObject.WarningTextMessageText();
            Console.WriteLine(warning);
        }
    }
}

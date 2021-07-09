using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using TestTorrowtech.Drivers;
using TestTorrowtech.Pages;
using TestTorrowtech.RequestApi;

namespace TestTorrowtech.Steps
{
    [Binding]
    public sealed class AuthSteps
    {
        private IWebDriver Driver;
        private readonly ScenarioContext _scenarioContext;

        public AuthSteps(ScenarioContext _scenarioContext)
        {
            this._scenarioContext = _scenarioContext;
        }

        [Given("go to the site torrow")]
        public void GetInTorrow()
        {
            Driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            Driver.Navigate().GoToUrl("https://dev1.torrow.net");
        }

        [When("enter phone number (.*) and wait (.*) sec")]
        public void EnterPhoneNumber(string number, int wait)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.SignIn();
            loginPage.showKeyboard().
                WriteNumber(number).
                SubmitNumber();
            Thread.Sleep(wait * 1000);
        }

        [When("enter code of phone message from number (.*)")]
        public void EnterNormalCode(string number)
        {
            CodePage codePage = new CodePage(Driver);
            string codeString = Request.GetCodeForMobileNumber(number);
            if (codeString.StartsWith("Новый код доступа"))
            {
                codePage.WriteRightCode(codeString.Substring(28));
            } else
            {
                codePage.WriteRightCode(codeString.Substring(23));
            }
        }

        [When("enter wrong code (.*) times for (.*)")]
        public void EnterWrongCodeThreeTimes(int times, string number)
        {
            string code = Request.GetCodeForMobileNumber(number)
                .Substring(28);
            string wrongCode = code.Equals("1111") ? "2222" : "1111";
            CodePage codePage = new CodePage(Driver);

            for (int i = 0; i < times-1; i++)
            {
                codePage.WriteNumber(wrongCode);
                codePage.AssertWarning();
            }
            codePage.WriteNumber(wrongCode);
        }

        [When("wait (.*) second")]
        public void WaitSecond(int second)
        {
            Thread.Sleep(second * 1000);
        }

        [When("change language en")]
        public void ChangeLanguageEn()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.ChangeLanguageEn();
        }

        [Then("auth succsess")]
        public void CheckSuccsessfulAuth()
        {
            SavesPage savesPage = new SavesPage(Driver);
        }

        [Then("go to login page")]
        public void CheckLoginPage()
        {
            LoginPage login = new LoginPage(Driver);
        }
    }
}

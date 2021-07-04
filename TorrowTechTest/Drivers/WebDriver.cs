using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TorrowTechTest.Drivers
{
    public class WebDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public WebDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService("C:\\Users\\Вова\\source\\repos\\TorrowTechTest\\TorrowTechTest\\Drivers");
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-notifications");
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            return chromeDriver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}

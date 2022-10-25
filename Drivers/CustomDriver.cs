using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyDemo.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetEdgeDriver()
        {
            return GetDriver(Browsers.Edge);
        }
        
        public static IWebDriver GetChromeIncognitoDriver()
        {
            return GetDriver(Browsers.IncognitoChrome);
        }

        private static IWebDriver GetDriver(Browsers myDriver)
        {
            IWebDriver webDriver;
            switch(myDriver)
            {
                case Browsers.Edge:
                    webDriver = new EdgeDriver();
                    break;
                case Browsers.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browsers.IncognitoChrome:
                    webDriver = GetChromeWithOptions();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            //webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return webDriver;
        }

        private static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            //options.AddArguments("incognito", "start-maximized");
            return new ChromeDriver(options);

        }

    }
}

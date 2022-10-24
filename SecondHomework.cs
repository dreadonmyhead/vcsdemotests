using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MyDemo
{
    public class SecondHomework
    {
        [TestCase("Chrome", "Chrome 106 on Windows 10", TestName = "Testing Chrome")]
        [TestCase("Firefox", "Firefox 106 on Windows 10", TestName = "Testing Firefox")]
        [TestCase("Edge", "Edge 106 on Windows 10", TestName = "Testing Edge")]
        public static void TestBrowsers(string browser, string text)
        {
            IWebDriver driver = null;

            if ("Chrome".Equals(browser))
            {
                driver = new ChromeDriver();
            }

            if ("Firefox".Equals(browser))
            {
                driver = new FirefoxDriver();
            }

            if ("Edge".Equals(browser))
            {
                driver = new EdgeDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            IWebElement actualResultElement = driver.FindElement(By.CssSelector(".simple-major"));

            Assert.AreEqual(text, actualResultElement.Text, $"Browser is not {browser}");
            driver.Quit();
        }
    }
}

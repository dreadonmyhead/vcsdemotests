using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NewDemoProject
{
    class WebdriverTest
    {

        [Test]
        public static void FirefoxTest()
        {
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "https://login.yahoo.com/";
            firefoxDriver.Manage().Window.Maximize();
            firefoxDriver.Quit();
        }

        [Test]
        public static void ChromeTest()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://login.yahoo.com/";
            chromeDriver.Manage().Window.Maximize();

            IWebElement emailInsertField = chromeDriver.FindElement(By.Id("login-username"));

            //IWebElement emailInsertField = chromeDriver.FindElement(By.CssSelector("#login-username"));

            emailInsertField.SendKeys("Test123");
            chromeDriver.Quit();
        }

        [Test]
        public static void TestSeleniumPage()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chromeDriver.Manage().Window.Maximize();

            IWebElement inputField = chromeDriver.FindElement(By.Id("user-message"));
            string myText = "vera11111";
            inputField.SendKeys(myText);

            IWebElement button = chromeDriver.FindElement(By.CssSelector("#get-input > button"));
            button.Click();

            IWebElement resultElement = chromeDriver.FindElement(By.Id("display"));
           
            Assert.AreEqual(myText, resultElement.Text, "Text is not the same");
            chromeDriver.Quit();
        }

    }
}


using MyDemo.Drivers;
using MyDemo.Page;
using MyDemo.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MyDemo.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;

        protected static CheckboxPage checkboxPage;
        protected static DropdownPage dropdownPage;
        protected static FirstSeleniumInputPage firstSeleniumInputPage;
        protected static SebPage sebPage;
        protected static KnygosltPage knygosltPage;
        protected static AlertPage alertPage;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            driver = CustomDriver.GetChromeIncognitoDriver();
            checkboxPage = new CheckboxPage(driver);
            dropdownPage = new DropdownPage(driver);
            sebPage = new SebPage(driver);
            knygosltPage = new KnygosltPage(driver);
            alertPage = new AlertPage(driver);
            firstSeleniumInputPage = new FirstSeleniumInputPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //driver.Quit();
        }
    }
}

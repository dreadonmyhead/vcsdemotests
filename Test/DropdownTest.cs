using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NewDemoProject.Page;
using System.Collections.Generic;
using System.Linq;

namespace NewDemoProject.Test
{
    public class DropdownTest
    {
        private static IWebDriver chromeDriver;
        private static DropdownPage page;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }

        [TestCase("Monday", TestName = "Testing Monday")]
        [TestCase("Wednesday", TestName = "Testing Wednesday")]
        [TestCase("Sunday", TestName = "Testing Sunday")]
        [TestCase("Tuesday", TestName = "Testing Tuesday")]
        public static void SimpleDropdownTest(string dayOfWeek)
        {
            page = new DropdownPage(chromeDriver);

            page.NavigateToPage();
            page.SelectFromFirstDropdownByText(dayOfWeek);
            page.VerifyFirstDropdownResult(dayOfWeek);
        }

        [TestCase("California", "New York", "Washington", TestName = "Testing California, New York, Washington")]
        [TestCase("California", "New York", "Washington", "Pennsylvania", TestName = "Testing California, New York, Washington")]
        [TestCase("California", "New York", TestName = "Testing California, New York, Washington")]
        public static void MultipleDropdownTest(params string[] states)
        {
            page = new DropdownPage(chromeDriver);

            page.NavigateToPage();
            page.SelectFromMultiDropdown(states.ToList());
            page.ClickPrintMeButton();

        }

    }
}

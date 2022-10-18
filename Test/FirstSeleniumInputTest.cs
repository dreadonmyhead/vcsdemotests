using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using NewDemoProject.Page;

namespace NewDemoProject.Test
{
    public class FirstSeleniumInputTest
    {
        private static IWebDriver chromeDriver;

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


        [TestCase("vera", TestName = "Irasom teksta vera")]
        [TestCase("sdfsdfsdf", TestName = "Irasom teksta sdfsdfsdf")]
        [TestCase("null", TestName = "Irasom teksta null")]
        public static void TestFirstInput(string myText)
        {
            FirstSeleniumInputPage page = new FirstSeleniumInputPage(chromeDriver);

            page.NavigateToPage();
            page.InsertTextToInputField(myText);
            page.ClickButton();
            page.VerifyResult(myText);
        }

        [TestCase("2", "2", "4", TestName = "Testas 2 plius 2")]
        [TestCase("-5", "3", "-2", TestName = "Testas -5 plius 3")]
        [TestCase("a", "b", "NaN", TestName = "Testas a plius b")]
        public static void TestSum(string firstInputValue, string secondInputValue, string resultValue)
        {
            FirstSeleniumInputPage page = new FirstSeleniumInputPage(chromeDriver);

            page.NavigateToPage();
            page.InsertBothInputs(firstInputValue, secondInputValue);


            page.InsertTextToFieldA(firstInputValue);


            page.ClickTotalButton();
            page.VerifyTotalResult(resultValue);

        }

    }
}

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewDemoProject
{
    class FirstHomework
    {
        private static IWebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }

        [TestCase("2", "2", "4", TestName ="Testas 2 plius 2")]
        [TestCase("-5", "3", "-2", TestName ="Testas -5 plius 3")]
        [TestCase("a", "b", "NaN", TestName ="Testas a plius b")]
        public static void TestSum(string firstInputValue, string secondInputValue, string resultValue)
        {
            IWebElement inputFieldA = chromeDriver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(firstInputValue);

            IWebElement inputFieldB = chromeDriver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(secondInputValue);

            chromeDriver.FindElement(By.CssSelector("#gettotal>button")).Click();

            IWebElement element = chromeDriver.FindElement(By.CssSelector("#displayvalue"));
            Assert.IsTrue(resultValue.Equals(element.Text), $"Result is not correct, actual result {element.Text}, but expected {resultValue}");  
        }
    }
}

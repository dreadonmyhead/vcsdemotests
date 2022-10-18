using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NewDemoProject
{
    class CheckboxDemo
    {
        private static IWebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }

        [Order(3)]
        [Test]
        public static void OneCheckboxTest()
        {
            IWebElement oneCheckBox = chromeDriver.FindElement(By.Id("isAgeSelected"));

            if (!oneCheckBox.Selected)
            {
                oneCheckBox.Click();
            }

            IWebElement resultElement = chromeDriver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", resultElement.Text, "Result text is wrong");
        }

       
        [Test]
        [Order(1)]
        public static void CheckboxesTest()
        {

            CheckAllChekboxes();

            IWebElement button = chromeDriver.FindElement(By.CssSelector("#check1"));
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")),
                "Button value is not correct");

        }

       
        [Test]
        [Order(2)]
        public static void UncheckCheckboxesTest()
        {
            CheckAllChekboxes();

            IWebElement button = chromeDriver.FindElement(By.CssSelector("#check1"));
            button.Click();

            Assert.IsTrue("Check All".Equals(button.GetAttribute("value")),
                "Button value is not correct");

            foreach (IWebElement checkbox in GetCeckboxesCollection())
            {
                Assert.That(!checkbox.Selected, "Check box was not unselected");
            }

        }

        private static IReadOnlyCollection<IWebElement> GetCeckboxesCollection()
        {
            return chromeDriver.FindElements(By.CssSelector(".cb1-element"));
        }

        private static void CheckAllChekboxes()
        {
            IReadOnlyCollection<IWebElement> checkboxesCollection
               = GetCeckboxesCollection();

            foreach (IWebElement checkbox in checkboxesCollection)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }
    }
}

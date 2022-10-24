using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using static System.Net.WebRequestMethods;

namespace MyDemo.Page
{
    public class CheckboxPage : BasePage
    {
        private const string pageUrl = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement oneCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> checkboxes => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement button => Driver.FindElement(By.CssSelector("#check1"));


        public CheckboxPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }
        }

         public void ClickOnFirstCheckbox()
        {
            if (!oneCheckBox.Selected)
            {
                oneCheckBox.Click();
            }
        }

        public void VerifyFirstCheckbox()
        {
            Assert.AreEqual("Success - Check box is checked", resultElement.Text, "Result text is wrong");
        }

        public void CheckAllChekboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

        public void ClickOnButton()
        {
            button.Click();
        }

        public void VerifyButtonValue(string value)
        {
            Assert.IsTrue(value.Equals(button.GetAttribute("value")),  "Button value is not correct");
        }

        public void VerifyCheckboxesState()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                Assert.That(!checkbox.Selected, "Check box was not unselected");
            }
        }
    }
}

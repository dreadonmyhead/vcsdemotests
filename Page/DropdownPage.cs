using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NewDemoProject.Page
{
    public class DropdownPage : BasePage
    {
        private const string pageUrl = "http://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

        private SelectElement firstDropdown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private SelectElement multiDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement printMeButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement printMeButton => Driver.FindElement(By.Id("printAll"));

        public DropdownPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }

        }

        public void SelectFromFirstDropdownByText(string text)
        {
            firstDropdown.SelectByText(text);
        }

        public void SelectFromFirstDropdownByValue(string value)
        {
            firstDropdown.SelectByValue(value);
        }

        public void VerifyFirstDropdownResult(string resultText)
        {
            //Assert.IsTrue(resultElement.Text.Equals("Day selected :- " + resultText), "Text is wrong");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement, "Day selected :- " + resultText));

            Assert.IsTrue(resultElement.Text.Contains(resultText), "Text is wrong");
        }


        public void SelectFromMultiDropdown(List<string> states)
        {
            Actions action = new Actions(Driver);

            IList<IWebElement> dropdownOptions = multiDropdown.Options;
            action.KeyDown(Keys.Control);
            foreach (IWebElement option in dropdownOptions)
            {
                if (states.Contains(option.Text))
                {
                    option.Click();
                }
            }

            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }

        public void ClickPrintMeButton()
        {
            printMeButton.Click();
        }

        public void ClickPrintAllButton()
        {
            printAllButton.Click();
        }
    }
}

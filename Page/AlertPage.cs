using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyDemo.Page
{
    public class AlertPage : BasePage
    {
        //private const string pageUrl = "http://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        private const string pageUrl = "https://www.eurovaistine.lt/";
        private IWebElement firstAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement secondAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement thirdAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));
        private IWebElement resultElement => Driver.FindElement(By.Id("confirm-demo"));

        public AlertPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }
        }

        public void ClickOnFirstAlertButton()
        {
            firstAlertButton.Click();
        }

        public void ClosePopup()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => Driver.FindElement(By.CssSelector(".PopupCloseButton__InnerPopupCloseButton-sc-957qyh-0.cMdPwy.wisepops-close")).Displayed);
            Driver.FindElement(By.CssSelector(".PopupCloseButton__InnerPopupCloseButton-sc-957qyh-0.cMdPwy.wisepops-close")).Click();
        }

        public void ClickOnSecondAlertButton()
        {
            secondAlertButton.Click();
        }

        public void ClickOnThirdAlertButton()
        {
            thirdAlertButton.Click();
        }

        public void AcceptFirstAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void CloseSecondAlert(bool accept)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            if (accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

        }

        public void AssertSecondAlertText(bool accept)
        {
            if (accept)
            {
                Assert.That(resultElement.Text.Contains("OK"), "Text is wrong");
            }
            else
            {
                Assert.That(resultElement.Text.Contains("Cancel"), "Text is wrong");
            }

        }
    }
}

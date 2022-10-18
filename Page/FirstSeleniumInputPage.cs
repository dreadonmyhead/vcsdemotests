using NUnit.Framework;
using OpenQA.Selenium;

namespace NewDemoProject.Page
{
    public class FirstSeleniumInputPage : BasePage
    {
        private string pageAddress => "http://demo.seleniumeasy.com/basic-first-form-demo.html";
        private IWebElement inputField => Driver.FindElement(By.Id("user-message"));
        private IWebElement firstBlockButton => Driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement resultElement => Driver.FindElement(By.Id("display"));

        private IWebElement inputFieldA => Driver.FindElement(By.Id("sum1"));

        private IWebElement inputFieldB => Driver.FindElement(By.Id("sum2"));

        private IWebElement getTotalButton => Driver.FindElement(By.CssSelector("#gettotal>button"));

        private IWebElement totalResultElement => Driver.FindElement(By.CssSelector("#displayvalue"));

        public FirstSeleniumInputPage(IWebDriver webdriver) : base(webdriver) {
        }

        public void NavigateToPage()
        {
            Driver.Url = pageAddress;
        }

        public void InsertTextToInputField(string myText)
        {
            inputField.Clear();
            inputField.SendKeys(myText);
        }

        public void InsertBothInputs(string inputA, string inputB)
        {
            InsertTextToFieldA(inputA);
            InsertTextToFieldB(inputB);
        }

        public void InsertTextToFieldA(string inputA)
        {
            inputFieldA.Clear();
            inputFieldA.SendKeys(inputA);
        }

        public void InsertTextToFieldB(string inputB)
        {
            inputFieldB.Clear();
            inputFieldB.SendKeys(inputB);
        }

        public void ClickButton()
        {
            firstBlockButton.Click();
        }

        public void ClickTotalButton()
        {
            getTotalButton.Click();
        }

        public void VerifyResult(string resultText)
        {
            Assert.AreEqual(resultText, resultElement.Text, "Text is not the same");
        }

        public void VerifyTotalResult(string resultText)
        {
            Assert.AreEqual(resultText, totalResultElement.Text, "Text is not the same");
        }

    }
}

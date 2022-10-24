using NUnit.Framework;

namespace MyDemo.Test
{
    public class FirstSeleniumInputTest : BaseTest
    {
     
        [TestCase("vera", TestName = "Irasom teksta vera")]
        [TestCase("sdfsdfsdf", TestName = "Irasom teksta sdfsdfsdf")]
        [TestCase("null", TestName = "Irasom teksta null")]
        public static void TestFirstInput(string myText)
        {
            firstSeleniumInputPage.NavigateToPage();
            firstSeleniumInputPage.InsertTextToInputField(myText);
            firstSeleniumInputPage.ClickButton();
            firstSeleniumInputPage.VerifyResult(myText);
        }

        [TestCase("2", "2", "4", TestName = "Testas 2 plius 2")]
        [TestCase("-5", "3", "-2", TestName = "Testas -5 plius 3")]
        [TestCase("a", "b", "NaN", TestName = "Testas a plius b")]
        public static void TestSum(string firstInputValue, string secondInputValue, string resultValue)
        {

            firstSeleniumInputPage.NavigateToPage();
            firstSeleniumInputPage.InsertBothInputs(firstInputValue, secondInputValue);

            firstSeleniumInputPage.InsertTextToFieldA(firstInputValue);

            firstSeleniumInputPage.ClickTotalButton();
            firstSeleniumInputPage.VerifyTotalResult(resultValue);

        }
    }
}

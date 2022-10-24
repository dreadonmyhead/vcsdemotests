using NUnit.Framework;

namespace MyDemo.Test
{
    public class CheckboxTest : BaseTest
    {
        [Test]
        public static void FirstsCheckboxTest()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.ClickOnFirstCheckbox();
            checkboxPage.VerifyFirstCheckbox();
        }

        [Test]
        public static void CheckAllCheckboxesTest()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.CheckAllChekboxes();
            checkboxPage.VerifyButtonValue("Uncheck All");
        }

        [Test]
        public static void UncheckAllCheckboxesTest()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.CheckAllChekboxes();
            checkboxPage.ClickOnButton();
            checkboxPage.VerifyButtonValue("Check All");
            checkboxPage.VerifyCheckboxesState();
        }
    }
}

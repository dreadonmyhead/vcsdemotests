
using NUnit.Framework;

namespace MyDemo.Test
{
    public class AlertTest : BaseTest
    {
        [Test]
        public static void AcceptFirstAlert()
        {
            alertPage.NavigateToPage();
            alertPage.ClickOnFirstAlertButton();
            alertPage.AcceptFirstAlert();
        }

        [TestCase(true, TestName = "Accept second alert")]
        [TestCase(false, TestName = "Dissmis second alert")]
        public static void AcceptSecondAlert(bool accept)
        {
            alertPage.NavigateToPage();
            alertPage.ClickOnSecondAlertButton();
            alertPage.CloseSecondAlert(accept);
            alertPage.AssertSecondAlertText(accept);
        }

        [Test]
        public static void xdfsdf()
        {
            alertPage.NavigateToPage();
            alertPage.ClosePopup();
        }
    }
}

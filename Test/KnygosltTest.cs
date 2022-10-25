using NUnit.Framework;

namespace MyDemo.Test
{
    public class KnygosltTest : BaseTest
    {

        [Test]
        public static void TestKnygosLt()
        {
            knygosltPage.NavigateToPage();
            knygosltPage.AcceptCookies();
        }
    }
}

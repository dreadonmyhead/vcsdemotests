using NUnit.Framework;

namespace MyDemo.Test
{
    public class SebTest : BaseTest
    {
        [Test]
        public static void TestSebCalculator()
        {
            sebPage.NavigateToPage();
            sebPage.AcceptCookies();
            sebPage.InsertIncome("1000");
            sebPage.SelectValueFromCityDropdown("Klaipeda");
            sebPage.CalculateLoanAmount();
            sebPage.VerifyResult(75000);
        }
    }
}

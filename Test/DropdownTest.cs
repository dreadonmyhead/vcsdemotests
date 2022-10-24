using System;
using System.Linq;
using NUnit.Framework;

namespace MyDemo.Test
{
    public class DropdownTest : BaseTest
    {

        [TestCase(DayOfWeek.Monday, TestName = "Testing Monday")]
        [TestCase(DayOfWeek.Wednesday, TestName = "Testing Wednesday")]
        [TestCase(DayOfWeek.Sunday, TestName = "Testing Sunday")]
        [TestCase(DayOfWeek.Tuesday, TestName = "Testing Tuesday")]
        public static void SimpleDropdownTest(DayOfWeek dayOfWeek)
        {
            dropdownPage.NavigateToPage();
            dropdownPage.SelectFromFirstDropdownByText(dayOfWeek);
            dropdownPage.VerifyFirstDropdownResult(dayOfWeek);
        }

        [TestCase("California", "New York", "Washington", TestName = "Testing California, New York, Washington")]
        [TestCase("Ohio", "New York", "Washington", "Pennsylvania", TestName = "Testing Ohio, New York, Washington")]
        [TestCase("California", "New York", TestName = "Testing California, New York")]
        public static void MultipleDropdownTest(params string[] states)
        {


            dropdownPage.NavigateToPage();
            dropdownPage.SelectFromMultiDropdown(states.ToList());
            dropdownPage.ClickPrintMeButton();
            dropdownPage.VerifyFirstSelected(states.ToList().ElementAt(0));
        }

        [TestCase("California", "New York", "Washington", TestName = "Testing first button for California, New York, Washington")]
        [TestCase("Ohio", "New York", "Washington", "Pennsylvania", TestName = "Testing first button for Ohio, New York, Washington")]
        [TestCase("California", "New York", TestName = "Testing first button for California, New York")]
        public static void MultipleDropdownFirstOptionTest(params string[] states)
        {


            dropdownPage.NavigateToPage();
            dropdownPage.SelectFromMultiDropdown(states.ToList());
            dropdownPage.ClickPrintAllButton();
            dropdownPage.VerifyAllSelected(states.ToList());
        }

    }
}

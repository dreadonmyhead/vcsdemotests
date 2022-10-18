using System;
using System.Threading;
using NUnit.Framework;

namespace NewDemoProject
{
    public class SimpleTest
    {

        [Test]
        public static void FirstTest()
        {
            Assert.AreEqual(0, 4 % 2, "4 is not even");
            //Assert.IsTrue(0 == 4 % 2, "4 is not even");
        }

        [Test]
        public static void SecondTest()
        {
            DateTime currentDate = DateTime.Now;
            Assert.That(19 == currentDate.Hour);
        }

        [Test]
        public static void ThirdTest()
        {
            Assert.AreEqual(0, 995 % 3, "995 nesidalija is 3");
        }

        [Test]
        public static void WaitTest()
        {
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [Test]
        public static void DayOfWeekTest()
        {
            DateTime currentDate = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Thursday, currentDate.DayOfWeek, "Siandien ne ketvirtadienis");
        }

        [Test]
        public static void TestEvenNumberBetween1And10()
        {
            int counter = 0;
            for (int i = 1; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    counter++;
                }
            }
            Assert.AreEqual(4, counter, "We not have 4 even numbers between 1 and 10");
        }
    }
}

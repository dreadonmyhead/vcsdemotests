using OpenQA.Selenium;

namespace NewDemoProject.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }




    }
}

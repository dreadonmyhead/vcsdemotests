using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MyDemo.Page
{
    public class KnygosltPage : BasePage
    {
        private const string pageUrl = "https://www.knygos.lt/";

        public KnygosltPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }

        }

        public void AcceptCookies()
        {
            Cookie myCookie = new Cookie("cookieconsent_status",
                "allow",
                ".knygos.lt",
                "/",
                DateTime.Now.AddDays(2));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }
    }
}

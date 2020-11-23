using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebAutomationProject.Page_Objects
{
    public class HomePageObjects
    {
        private IWebDriver driver;
        public HomePageObjects(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}

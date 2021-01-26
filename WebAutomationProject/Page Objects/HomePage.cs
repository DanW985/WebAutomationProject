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

        public IWebElement signInBtn => driver.FindElement(By.ClassName("login"));


        public void clickTheSignInBtn()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            signInBtn.Click();
        }

    }
}

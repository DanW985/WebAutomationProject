using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WebAutomationProject.WebDriverExtenstions;



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

        public void hoverOverWomenClothesTab()
        {
            var womenClothesTab = driver.FindElement(By.LinkText("Women"), 10);
            Actions actions = new Actions(driver);
            actions.MoveToElement(womenClothesTab).Perform();
        }

    }
}

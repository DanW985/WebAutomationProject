using OpenQA.Selenium;
using NUnit.Framework;
using System;

namespace WebAutomationProject.Page_Objects
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement userNameTextBox => driver.FindElement(By.ClassName("account"));

        public void checkUserDetails(string firstName, string lastName)
        {
            string submittedUserName = string.Join(" ", firstName, lastName);
            string displayedUserName = userNameTextBox.Text;
            Console.WriteLine(submittedUserName);
            Console.WriteLine(displayedUserName);
            Assert.AreEqual(submittedUserName, displayedUserName);

            
        }
    }
}

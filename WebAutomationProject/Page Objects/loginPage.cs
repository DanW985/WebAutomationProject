using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebAutomationProject.WebDriverExtenstions;
using NUnit;
using NUnit.Framework;
using WebAutomationProject.TestDataCreator;
using System.Threading;

namespace WebAutomationProject.Page_Objects
{
    public class loginPage
    {
        private IWebDriver driver;

        public loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement emailAddressField => driver.FindElement(By.Id("email_create"));
        public IWebElement createAnAccountBtn => driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement accountAlreadyUsed => driver.FindElement(By.Id("create_account_error"));


        public void clickEmailAddressFieldAndEnterEmailAddress()
        {
            var testData = new CreateTestData();

            var emailAddressField = driver.FindElement(By.Id("email_create"), 10);
            emailAddressField.Click();
            string emailAddress = testData.createEmailAddress();
            emailAddressField.SendKeys(emailAddress);
            var emailAddressEntered = emailAddressField.GetAttribute("value");
            Assert.AreEqual(emailAddress, emailAddressEntered);
        }

        public void clickCreateAccountButton()
        {
            createAnAccountBtn.Click();
            Thread.Sleep(5000);
        }

    }
}

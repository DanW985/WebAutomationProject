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
        public IWebElement signInEmailAddressField => driver.FindElement(By.Id("email"));
        public IWebElement signInPasswordField => driver.FindElement(By.Id("passwd"));
        public IWebElement signInBtn => driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement invalidEmailAddressMessage => driver.FindElement(By.CssSelector("#center_column > div:nth-child(2)"));


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

        public void clickCreateAnAccountButton()
        {
            createAnAccountBtn.Click();
            Thread.Sleep(6000);
        }

        public void enterIncorrectEmailAddressPassword()
        {
            var createData = new CreateTestData();
            signInEmailAddressField.Click();
            string incorrectEmailAddress = createData.randomLetters(3, true);
            signInEmailAddressField.SendKeys(incorrectEmailAddress);
            signInPasswordField.Click();
            string password = createData.generatePassword(4, true);
            signInPasswordField.SendKeys(password);

        }
        public void clickSignInAndVerifyIfErrorIsDisplayed()
        {
            signInBtn.Click();
            if(invalidEmailAddressMessage.Displayed)
            {
                Assert.IsTrue(invalidEmailAddressMessage.Displayed);
            }else
            {
                throw new ElementNotVisibleException("Error Message Is Not Displayed");
            }
        }
        public void performLogin()
        {
            signInEmailAddressField.SendKeys("test1249@test.com");
            Thread.Sleep(500);
            signInPasswordField.SendKeys("PKR@PKR");
            Thread.Sleep(500);
            signInBtn.Click();
        }

    }
}

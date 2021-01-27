using System.Threading;
using OpenQA.Selenium;
using WebAutomationProject.TestDataCreator;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using WebAutomationProject.WebDriverExtenstions;

namespace WebAutomationProject.Page_Objects
{
    public class AccountCreationPage
    {
        string enteredFirstName;
        string enteredLastName;

        private IWebDriver driver;

        public AccountCreationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement mrRadioBtn => driver.FindElement(By.Id("id_gender1"));
        public IWebElement firstNamefield => driver.FindElement(By.Id("customer_firstname"));
        public IWebElement lastNamefield => driver.FindElement(By.Id("customer_lastname"));
        public IWebElement passwordField => driver.FindElement(By.Id("passwd"));
        public IWebElement addressFirstNameField => driver.FindElement(By.Id("firstname"));
        public IWebElement addressLastNameField => driver.FindElement(By.Id("lastname"));
        public IWebElement companyField => driver.FindElement(By.Id("company"));
        public IWebElement addressFied => driver.FindElement(By.Id("address1"));
        public IWebElement cityField => driver.FindElement(By.Id("city"));
        public IWebElement stateField => driver.FindElement(By.Id("id_state"));
        public IWebElement stateValue => driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[7]/div/select/option[2]"));
        public IWebElement zipPostalCodeField => driver.FindElement(By.Id("postcode"));
        public IWebElement mobileField => driver.FindElement(By.Id("phone_mobile"));
        public IWebElement registerBtn => driver.FindElement(By.Id("submitAccount"));
        public IWebElement emailAddressField => driver.FindElement(By.Id("email"));
        IWebElement errorMessageBox => driver.FindElement(By.CssSelector(".alert > ol:nth-child(2)"));
        
                    
        public void completePersonalInformation()
        {
            var testData = new CreateTestData();
            var myAccount = new MyAccountPage(driver);

            string password = testData.generatePassword(10, true);
            string firstName = testData.GenRandomFirstName();
            enteredFirstName = firstName;
            string lastName = testData.GenRandomLastName();
            enteredLastName = lastName;
            


            mrRadioBtn.Click();
            firstNamefield.Click();
            firstNamefield.SendKeys(firstName);
            lastNamefield.Click();
            lastNamefield.SendKeys(lastName);
            passwordField.SendKeys(password);
            string autoCompletedFirstName = addressFirstNameField.GetAttribute("value");
            string autoCompletedLastName = addressLastNameField.GetAttribute("value");
            Assert.AreEqual(firstName, autoCompletedFirstName);
            Assert.AreEqual(lastName, autoCompletedLastName);
        }

        public void completeAddressDetails()
        {
            var testData = new CreateTestData();

            companyField.Click();
            companyField.SendKeys("Automation Inc");
            addressFied.SendKeys("1 Test Street");
            cityField.SendKeys("Test city");
            stateField.Click();
            stateValue.Click();
            zipPostalCodeField.SendKeys("90210");
            string telNo = testData.GenRandomTelNo();
            mobileField.Click();
            mobileField.SendKeys(telNo);

        }

        public void clickTheRegisterButton()
        {
            registerBtn.Click();
            Thread.Sleep(2000);

        }

        public void checkThatTheUserIsRegistered()
        {
            var myAccount = new MyAccountPage(driver);
            myAccount.checkUserDetails(enteredFirstName, enteredLastName);
        }
        public void clearEmailAddressField()
        {
            var emailAddress = driver.FindElement(By.Id("email"), 10);
            emailAddress.Clear();
        }
        public void attemptRegistrationWithoutMandatoryFields()
        {
            mrRadioBtn.Click();
            registerBtn.Click();
        }
        public void checkThatTheExpectedErrorMessagesHaveDisplayed()
        {
            IEnumerable<string> allErrors = errorMessageBox.FindElements(By.TagName("li")).Select(iw => iw.Text);

            string phoneNumberErrorMessage = allErrors.ElementAt(0);
            string lastNameRequired = allErrors.ElementAt(1);
            string firstNameRequired = allErrors.ElementAt(2);
            string emailRequired = allErrors.ElementAt(3);
            string passwordRequired = allErrors.ElementAt(4);
            string address1Required = allErrors.ElementAt(5);
            string cityRequired = allErrors.ElementAt(6);
            string ZipPostalCodeNotValid = allErrors.ElementAt(7);
            string stateRequired = allErrors.ElementAt(8);

            Assert.IsTrue(phoneNumberErrorMessage.Contains("You must register at least one phone number"));
            Assert.IsTrue(lastNameRequired.Contains("lastname is required"));
            Assert.IsTrue(firstNameRequired.Contains("firstname is required"));
            Assert.IsTrue(emailRequired.Contains("email is required"));
            Assert.IsTrue(passwordRequired.Contains("passwd is required"));
            Assert.IsTrue(address1Required.Contains("address1 is required"));
            Assert.IsTrue(cityRequired.Contains("city is required"));
            Assert.IsTrue(ZipPostalCodeNotValid.Contains("The Zip/Postal code you've entered is invalid. It must follow this format: 00000"));
            Assert.IsTrue(stateRequired.Contains("This country requires you to choose a State."));

        } 
        public void enterIncorrectRegistrationDetailsToTriggerErrors()
        {
            firstNamefield.SendKeys("1234");
            Thread.Sleep(500);
            lastNamefield.SendKeys("5678");
            Thread.Sleep(500);
            passwordField.SendKeys("password");
            Thread.Sleep(500);
            zipPostalCodeField.SendKeys("ABC");
            Thread.Sleep(500);
            mobileField.SendKeys("my mobile");
            Thread.Sleep(500);
            registerBtn.Click();
            Thread.Sleep(1000);
        }

        public void checkThatTheExpectedErrorsAreDisplayed()
        {
            IEnumerable<string> allErrors = errorMessageBox.FindElements(By.TagName("li")).Select(iw => iw.Text);
            Console.WriteLine(allErrors);

            string lastnameInvalid = allErrors.ElementAt(0);
            string firstnameInvalid = allErrors.ElementAt(1);
            string mobilePhoneInvalid = allErrors.ElementAt(4);
            string zipPostalCodeInvalid = allErrors.ElementAt(5);

            Assert.IsTrue(lastnameInvalid.Contains("lastname is invalid."));
            Assert.IsTrue(firstnameInvalid.Contains("firstname is invalid."));
            Assert.IsTrue(mobilePhoneInvalid.Contains("phone_mobile is invalid."));
            Assert.IsTrue(zipPostalCodeInvalid.Contains("The Zip/Postal code you've entered is invalid. It must follow this format: 00000"));
        }
    }
}

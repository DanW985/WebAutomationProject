using System.Threading;
using OpenQA.Selenium;
using WebAutomationProject.TestDataCreator;
using NUnit.Framework;

namespace WebAutomationProject.Page_Objects
{
    public class AccountCreationPage
    {
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


        public void completePersonalInformation()
        {
            var testData = new CreateTestData();

            string password = testData.generatePassword(10, true);
            string firstName = testData.GenRandomFirstName();
            string lastName = testData.GenRandomLastName();


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
    }
}

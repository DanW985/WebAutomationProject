using NUnit.Framework;
using System;
using System.Configuration;
using System.Reflection;
using WebAutomationProject.ScreenshotManager;
using WebAutomationProject.BaseClass;
using WebAutomationProject.Page_Objects;


namespace WebAutomationProject
{
    
   
    public class Tests : Base
    {
        
        [Test]
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_1_Automate_Registration(string browserName)
        {
            try
            {


                Setup(browserName);
                var homePage = new HomePageObjects(driver);
                var loginPage = new loginPage(driver);
                var registration = new AccountCreationPage(driver);

                homePage.clickTheSignInBtn();
                loginPage.clickEmailAddressFieldAndEnterEmailAddress();
                loginPage.clickCreateAnAccountButton();
                registration.completePersonalInformation();
                registration.completeAddressDetails();
                registration.clickTheRegisterButton();
                registration.checkThatTheUserIsRegistered();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var screenshot = new Screenshots(driver);
                string fileName = MethodBase.GetCurrentMethod().Name;
            }
        }
        [Test]
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_2_Verify_Invalid_Email_Address_Error(string browserName)
        {
            Setup(browserName);
            var homePage = new HomePageObjects(driver);
            var loginPage = new loginPage(driver);

            homePage.clickTheSignInBtn();
            loginPage.enterIncorrectEmailAddressPassword();
            loginPage.clickSignInAndVerifyIfErrorIsDisplayed();

        }

        [Test]
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_3_Verify_Error_Messages_For_Mandatory_Fields(string browserName)
        {
            Setup(browserName);
            var homePage = new HomePageObjects(driver);
            var loginPage = new loginPage(driver);
            var createAccount = new AccountCreationPage(driver);

            homePage.clickTheSignInBtn();
            loginPage.clickEmailAddressFieldAndEnterEmailAddress();
            loginPage.clickCreateAnAccountButton();
            createAccount.clearEmailAddressField();
            createAccount.attemptRegistrationWithoutMandatoryFields();
            createAccount.checkThatTheExpectedErrorMessagesHaveDisplayed();

        }
        [Test]
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_4_Verify_Error_Messages_For_Incorrect_Values(string browserName)
        {
            Setup(browserName);
            var homePage = new HomePageObjects(driver);
            var loginPage = new loginPage(driver);
            var createAccount = new AccountCreationPage(driver);

            homePage.clickTheSignInBtn();
            loginPage.clickEmailAddressFieldAndEnterEmailAddress();
            loginPage.clickCreateAnAccountButton();
            createAccount.enterIncorrectRegistrationDetailsToTriggerErrors();
            createAccount.checkThatTheExpectedErrorsAreDisplayed();
        }
        [Test]
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_5_Automate_End_To_End_Order(string browserName)
        {
            Setup(browserName);

            var homePage = new HomePageObjects(driver);
            var loginPage = new loginPage(driver);

            homePage.clickTheSignInBtn();
            loginPage.performLogin();
            homePage.hoverOverWomenClothesTab();

        }
    }
}
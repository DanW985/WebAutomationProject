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
                loginPage.clickCreateAccountButton();
                registration.completePersonalInformation();
                registration.completeAddressDetails();
                registration.clickTheRegisterButton();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var screenshot = new Screenshots(driver);
                string fileName = MethodBase.GetCurrentMethod().Name;
            }
        }
    }
}
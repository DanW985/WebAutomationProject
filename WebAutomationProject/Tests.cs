using NUnit.Framework;
using System;
using System.Configuration;
using AventStack.ExtentReports;
using System.Reflection;
using WebAutomationProject.ScreenshotManager;
using WebAutomationProject.BaseClass;
using WebAutomationProject.Page_Objects;
using WebAutomationProject.Report_Manager;

namespace WebAutomationProject
{
   
    public class Tests : Base
    {

        public static ExtentReports extent;
        public static ExtentTest test;
        private string URL = ConfigurationManager.AppSettings["URL"];
        

        [Test]
        [TestCaseSource(typeof(BaseClass.Base), "Browsers")]
        public void Navigate_To_Storefront(string browserName)
        {
            try
            {

                Setup(browserName);

                test = extent.CreateTest("Navigate To Store front").Info("Test Started");

                

                var homePage = new HomePageObjects(driver);

                test.Log(Status.Info, "Opening URL " + URL);
                driver.Navigate().GoToUrl(URL);

            }catch(Exception ex)
            {

                test.Log(Status.Fail, ex.ToString());
                var screenshot = new Screenshots(driver);
                string fileName = MethodBase.GetCurrentMethod().Name;
                

            }
        }
        [TestCaseSource(typeof(Base), "Browsers")]
        public void Test_Case_1_Automate_Registration()
        {
            try
            {

                test = extent.CreateTest("Test Case 1 - Automate Registrtaion").Info("Test Started");


            }catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                var screenshot = new Screenshots(driver);
                string fileName = MethodBase.GetCurrentMethod().Name;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;

namespace WebAutomationProject.BaseClass
{
    
    public class Base
    {
        private string URL = ConfigurationManager.AppSettings["URL"];

        public static ExtentReports extent;
        
        public static IWebDriver driver;

       public static IWebDriver GetDriver
        {
            get { return driver; }
        }

        public void Setup(string browserName)
        {
           
            //var ieOptions = new InternetExplorerOptions();
            //ieOptions.EnsureCleanSession = true;
            //ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //ieOptions.EnableNativeEvents = true;
            //ieOptions.EnablePersistentHover = false;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");

            //if (browserName.Equals("Internet Explorer"))
                //driver = new InternetExplorerDriver(ieOptions);
            if (browserName.Equals("Google Chrome"))
                driver = new ChromeDriver(@"C:\Users\User\source\repos\DanW985\WebAutomationProject\WebDrivers\");
            else if (browserName.Equals("Firefox"))
                driver = new FirefoxDriver();
            else if (browserName.Equals("Chrome Headless"))
                driver = new ChromeDriver(chromeOptions);
            else throw new NotImplementedException();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);

        }

        public static IEnumerable<string> Browsers()
        {
            string[] browsers = { "Google Chrome", "Firefox", "Chrome Headless" };
            foreach (string b in browsers)
            {
                yield return b;
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
        [OneTimeTearDown]
        public void exntentEnd()
        {
            extent.Flush();
            
        }
    }


}

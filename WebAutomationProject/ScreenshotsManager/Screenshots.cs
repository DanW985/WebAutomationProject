using System;
using OpenQA.Selenium;
using System.Security.AccessControl;
using System.IO;



namespace WebAutomationProject.ScreenshotManager
{
    
    public class Screenshots
    {

        private IWebDriver driver;

        public Screenshots(IWebDriver driver)
        {
            this.driver = driver;
        }

        public const string FilePath = @"C:\Users\User\source\repos\WebAutomationProject\Screenshots";

        public static void SetAccessRule(string directory)
        {
            DirectoryInfo dInfo = new DirectoryInfo(directory);
            DirectorySecurity sec = dInfo.GetAccessControl();
            FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
            sec.AddAccessRule(accRule);
        }

        public string setdateAndTime()
        {
            string DateAndTime = DateTime.Now.ToString("dd-MM-yy HH-mm-ss-ms");
            return DateAndTime;
        }

        public void takeScreenshot(IWebDriver driver, string fileName, string browserName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(Path.Combine(FilePath, fileName + setdateAndTime() + ".png"), ScreenshotImageFormat.Png);
        }

    }
}

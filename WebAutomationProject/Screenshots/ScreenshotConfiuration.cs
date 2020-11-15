using System;
using OpenQA.Selenium;
using System.Security.AccessControl;
using System.IO;



namespace WebAutomationProject.Screenshots
{
    class ScreenshotConfiuration
    {

        public static void SetAccessRule(string directory)
        {
            DirectoryInfo dInfo = new DirectoryInfo(directory);
            DirectorySecurity sec = dInfo.GetAccessControl();
            FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
            sec.AddAccessRule(accRule);
        }

        public static string getDirectory()
        {

            string FilePath = "FilePath";
            SetAccessRule(FilePath);
            return FilePath;
        }

        public string setdateAndTime()
        {
            string DateAndTime = DateTime.Now.ToString("dd-MM-yy HH-mm-ss-ms");
            return DateAndTime;
        }

        public void takeScreenshot(IWebDriver driver, string fileName, string browserName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(Path.Combine(fileName + setdateAndTime() + ".png"), ScreenshotImageFormat.Png);
        }

    }
}

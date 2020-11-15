using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace WebAutomationProject.Report_Manager
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;

        public static ExtentReports extent;

        private ExtentManager()
        {

        }

        public static ExtentReports getInstance()
        {
            try
            {
                if(extent == null) 
                {
                    string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    string reportPath = @"ReportPath";
                    htmlReporter = new ExtentHtmlReporter(reportPath);
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);               
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return extent;  
        }
    }
}

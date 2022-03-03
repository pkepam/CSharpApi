using Automation.Ui.Accelerators.Constants;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Automation.Ui.Reporting.ReportingClasses
{
    public class ExtentManager
    {
        public static readonly object synchroniser = new object();
        

        public static AventStack.ExtentReports.ExtentReports extent = new AventStack.ExtentReports.ExtentReports();
        private static string newPath = Constants.NewPath + DateTime.Now.ToString("yyyy_MM_dd_HHmm tt")+"\\";
        private static string reportpath = newPath + DateTime.Now.ToString("yyyy_MM_dd_HHmm tt");
        private static String reportFileName = " Execution Report" + DateTime.Now.ToString("yyyy_MM_dd_HHmm tt");


        public static AventStack.ExtentReports.ExtentReports createInstance()
        {

            var htmlReporter = new ExtentHtmlReporter(reportpath);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = reportFileName;
            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.ReportName = reportFileName;
            extent.AddSystemInfo("Operating System : ", Environment.OSVersion.ToString());
            extent.AddSystemInfo("Machine Name : ", Environment.MachineName);
            
            extent.AnalysisStrategy = AnalysisStrategy.BDD;

            extent.AttachReporter(htmlReporter);

            return extent;
        }
    }
}

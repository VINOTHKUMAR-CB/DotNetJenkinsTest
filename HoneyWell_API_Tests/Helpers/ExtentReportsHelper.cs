using AventStack.ExtentReports;
using System;

namespace HoneyWellAPITests.Helpers
{
    //This class prints messages to Extent Reports and NUnit Reports
    public class ExtentReportsHelper
    {
        #region ---Methods---

        //Prints exception details in Reports
        public static void PrintException(ExtentTest test, Exception e)
        {
            //string msg = e.Message + " Occurred at " + e.TargetSite + "\r\n" + e;
            string msg = e.Message + " Occurred at " + e.TargetSite;
            Console.WriteLine(msg);
            test.Info(msg);
        }

        //Prints info logs in Reports
        public static void LogMessage(ExtentTest test, string msg)
        {
            Console.WriteLine(msg);
            test.Info(msg);           
        }

        //Prints Pass Message in Reports
        public static void PassMessage(ExtentTest test, string msg)
        {
            Console.WriteLine(msg);
            test.Pass(msg);
        }

        //Prints Fail Message in Reports
        public static void FailMessage(ExtentTest test, string msg)
        {
            Console.WriteLine(msg);
            test.Fail(msg);
        }
        #endregion
    }
}

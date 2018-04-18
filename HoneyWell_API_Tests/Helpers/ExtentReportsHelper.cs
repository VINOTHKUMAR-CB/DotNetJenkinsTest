using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyWell_API_Tests.Helpers
{
    public class ExtentReportsHelper
    {
        #region ---Methods---

        //Prints exception details in the report
        public static void PrintException(ExtentTest test, Exception e)
        {
            string msg = "Exception Occurred at " + e.TargetSite + "\r\n" + e;
            Console.WriteLine(msg);
            test.Fail(msg);
        }
        #endregion
    }
}

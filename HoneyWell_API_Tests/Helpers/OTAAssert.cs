using AventStack.ExtentReports;
using NUnit.Framework;

namespace HoneyWellAPITests.Helpers
{
    public class OTAAssert
    {

        #region ---Methods---

        //Asserts if the condition is True
        public static void AssertTrue(ExtentTest extentTest, bool assertedValue)
        {
            try
            {
                Assert.IsTrue(assertedValue);
                LogTraceListener.TestStatusMessage = "Value = " + assertedValue;
                ExtentReportsHelper.PassMessage(extentTest, LogTraceListener.TestStatusMessage);
            }
            catch (AssertionException)
            {
                LogTraceListener.TestStatusMessage = "TEST FAILED : Expected TRUE but found " + assertedValue;
                ExtentReportsHelper.FailMessage(extentTest, LogTraceListener.TestStatusMessage);
            }
        }

        //Asserts if actual value if equal to the expected value
        public static void AssertEquals(ExtentTest extentTest, object actualValue, object expectedValue, string message)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue, message);
                LogTraceListener.TestStatusMessage = message;
                ExtentReportsHelper.PassMessage(extentTest, LogTraceListener.TestStatusMessage);
            }
            catch (AssertionException)
            {
                LogTraceListener.TestStatusMessage = "TEST FAILED : Expected = " + expectedValue + " but found " + actualValue;
                ExtentReportsHelper.FailMessage(extentTest, LogTraceListener.TestStatusMessage);
            }
        }

        #endregion
    }
}

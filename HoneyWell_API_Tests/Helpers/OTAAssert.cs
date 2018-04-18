using AventStack.ExtentReports;
using NUnit.Framework;

namespace HoneyWell_API_Tests.Helpers
{
    public class OTAAssert
    {

        #region ---Methods---

        //Asserts if the condition is True
        public static void AssertTrue(ExtentTest extentTest, bool assertedValue, string reportingMessage)
        {
            try
            {
                Assert.IsTrue(assertedValue);
                extentTest.Pass(reportingMessage);
            }
            catch (AssertionException)
            {
                extentTest.Fail("TEST FAILED : Expected TRUE but found " + assertedValue);
            }
        }

        //Asserts if actual value if equal to the expected value
        public static void AssertEquals(ExtentTest extentTest, int actualValue, int expectedValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
            }
            catch (AssertionException)
            {
                extentTest.Fail("TEST FAILED : Expected = " + expectedValue + " but found " + actualValue);              
            }
        }
        #endregion
    }
}

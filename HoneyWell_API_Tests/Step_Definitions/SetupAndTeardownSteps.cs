using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using HoneyWellAPITests.Globals;
using TechTalk.SpecFlow;

namespace HoneyWellAPITests.Step_Definitions
{
    [Binding]
    public class SetupAndTeardownSteps
    {
        #region ---Variables---
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;
        private static ExtentHtmlReporter htmlReporter;
        #endregion

        [BeforeFeature]
        public static void InitializeReport()
        {
            extentReports = new ExtentReports();

            htmlReporter = new ExtentHtmlReporter(Constants.ReportingFolder + FeatureContext.Current.FeatureInfo.Title + ".html");

            htmlReporter.Configuration().Theme = Theme.Dark;

            extentReports.AttachReporter(htmlReporter);

            FeatureContext.Current.Set<ExtentReports>(extentReports);
        }

        [BeforeScenario]
        public static void InitializeReportTest()
        {
            extentTest = FeatureContext.Current.Get<ExtentReports>().CreateTest(ScenarioContext.Current.ScenarioInfo.Title, "This test is to check the status of API under test");
            ScenarioContext.Current.Set<ExtentTest>(extentTest);
        }

        [AfterScenario]
        public static void WriteTestDescription()
        {
            #region @NUnit marking all tests as Inconclusive
            //var status = TestContext.CurrentContext.Result.Outcome.Status;
            ////Status logStatus;
            //switch (status)
            //{
            //    case TestStatus.Passed:
            //        //logStatus = Status.Pass;
            //        extentTest.Pass(LogTraceListener.TestStatusMessage);
            //        break;
            //    case TestStatus.Failed:
            //        //logStatus = Status.Fail;
            //        extentTest.Fail(LogTraceListener.TestStatusMessage);

            //        break;
            //    case TestStatus.Inconclusive:
            //        //logStatus = Status.Warning;
            //        extentTest.Warning(LogTraceListener.TestStatusMessage);
            //        break;
            //    case TestStatus.Skipped:
            //        //logStatus = Status.Skip;
            //        extentTest.Skip(LogTraceListener.TestStatusMessage);
            //        break;
            //    default:
            //        //logStatus = Status.Info;
            //        extentTest.Info(LogTraceListener.TestStatusMessage);
            //        break;
            //}
            #endregion

            ScenarioContext.Current.Clear();
        }

        //[BeforeStep]
        //public static void LogCurrentStep()
        //{
        //    ScenarioContext.Current.Get<ExtentTest>().Info(LogTraceListener.LastGherkinMessage);
        //}

        [AfterFeature]
        public static void FlushReport()
        {
            FeatureContext.Current.Get<ExtentReports>().Flush();

            FeatureContext.Current.Clear();
        }
    }
}

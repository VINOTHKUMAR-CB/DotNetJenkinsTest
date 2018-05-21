using System;
using TechTalk.SpecFlow.Tracing;

namespace HoneyWellAPITests.Helpers
{
    public class LogTraceListener : ITraceListener
    {
        #region ---Variables---
        static public string LastGherkinMessage;
        static public string TestStatusMessage;
        #endregion

        #region ---Methods---
        public void WriteTestOutput(string message)
        {
            LastGherkinMessage = message;

            Console.WriteLine(message);
        }

        public void WriteToolOutput(string message)
        {
            Console.WriteLine(message);
        }

        #endregion
    }
}
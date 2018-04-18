using System;
using TechTalk.SpecFlow.Tracing;

namespace HoneyWell_API_Tests.Helpers
{
    public class LogTraceListener : ITraceListener
    {
        #region ---Variables---
        static public string LastGherkinMessage;
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
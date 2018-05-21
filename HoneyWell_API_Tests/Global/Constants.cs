using System;

namespace HoneyWellAPITests.Globals
{
    public class Constants
    {
        public const int DefaultTimeout = 30;
        public static string ReportingFolder = Environment.CurrentDirectory.Replace("\\TestResults", "\\Reports\\");
        public const string JsonFolderName = "\\JsonInputFiles\\";
    }
}

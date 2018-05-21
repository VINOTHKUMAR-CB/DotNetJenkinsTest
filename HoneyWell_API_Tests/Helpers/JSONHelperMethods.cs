using AventStack.ExtentReports;
using HoneyWellAPITests.Globals;
using Newtonsoft.Json;
using System;
using System.IO;

namespace HoneyWellAPITests.Helpers
{
    public class JSONHelperMethods
    {

        #region ---Methods---

        //Serialize Json object to string
        public static string SerializeJson<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        //Deserialize Json to object
        public static T DeserializeJson<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        //Creates and writes content to Json File
        public static void WriteToJsonFile<T>(string fileName, T ap, ExtentTest test)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + Constants.JsonFolderName))
                    Directory.CreateDirectory(Environment.CurrentDirectory + Constants.JsonFolderName);

                //string path = Environment.CurrentDirectory + Constants.JsonFolderName + fileName + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
                string path = Environment.CurrentDirectory + Constants.JsonFolderName + fileName + ".json";

                File.WriteAllText(path, SerializeJson<T>(ap));
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, ap);
                    ExtentReportsHelper.LogMessage(test, "Json Contents were successfully written to -> " + path);
                }
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }
        }

        //Read data from json file
        public static T ReadFromJsonFile<T>(string fileName)
        {
            string path1 = Environment.CurrentDirectory + Constants.JsonFolderName + fileName + ".json";
            T authparams = DeserializeJson<T>(File.ReadAllText(path1));
            return authparams;
        }
        #endregion
    }
}

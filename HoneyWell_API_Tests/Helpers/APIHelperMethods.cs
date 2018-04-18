using AventStack.ExtentReports;
using RestSharp;
using System;
using System.Net;

namespace HoneyWell_API_Tests.Helpers
{
    public class APIHelperMethods
    {
        #region ---Variables---
        #endregion

        #region ---Methods---

        //Sends request to Post API
        public static RestRequest RequestPOSTAPI(ref RestClient restClient, RestRequest restRequest, string url, string jsonBody, ExtentTest test)
        {

            try
            {
                restClient = new RestClient(url);
                Console.WriteLine("Request Type of API : POST");
                restRequest = new RestRequest(Method.POST);
                restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

            return restRequest;
        }

        //Sends request to Get API
        public static RestRequest RequestGETAPI(ref RestClient restClient, RestRequest restRequest, string url, ExtentTest test)
        {

            try
            {
                restClient = new RestClient(url);
                Console.WriteLine("Request Type of API : GET");
                restRequest = new RestRequest(Method.GET);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);

            }

            return restRequest;
        }
     
        //Sends request to Update API
        public static RestRequest RequestUPDATEAPI(ref RestClient restClient, RestRequest restRequest, string url, ExtentTest test)
        {
            try
            {
                restClient = new RestClient(url);
                restRequest = new RestRequest(Method.PUT);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

            return restRequest;
        }

        //Sends request to Delete API
        public static RestRequest RequestDELETEAPI(ref RestClient restClient, RestRequest restRequest, string url, ExtentTest test)
        {
            try
            {
                restClient = new RestClient(url);
                restRequest = new RestRequest(Method.DELETE);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

            return restRequest;

        }

        //Sends request to Patch API
        public static RestRequest RequestPATCHAPI(ref RestClient restClient, RestRequest restRequest, string url, ExtentTest test)
        {
            try
            {
                restClient = new RestClient(url);
                restRequest = new RestRequest(Method.PATCH);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

            return restRequest;

        }

        //Returns the Status Code of the API
        public static int StatusCode(IRestResponse restResponse, ExtentTest test)
        {
            int numericStatusCode = 0;
            try
            {
                HttpStatusCode statusCode = restResponse.StatusCode;
                numericStatusCode = (int)statusCode;
                Console.WriteLine("Status Code = " + numericStatusCode);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

            return numericStatusCode;
        }

        //Prints Json response of the API on the console
        public static void SaveJSONResponse(IRestResponse restResponse, ExtentTest test)
        {
            try
            {
                string json = restResponse.Content;
                LogTraceListener.LastGherkinMessage = LogTraceListener.LastGherkinMessage + " \r\nJSON RESPONSE : " + json;
                Console.WriteLine(json);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

        }
        #endregion
    }
}

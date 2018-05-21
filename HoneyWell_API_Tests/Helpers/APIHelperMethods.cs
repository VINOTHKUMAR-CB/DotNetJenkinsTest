using AventStack.ExtentReports;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace HoneyWellAPITests.Helpers
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
                restRequest = new RestRequest(Method.GET);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);

            }

            return restRequest;
        }
     
        //Sends request to Update API
        public static RestRequest RequestUPDATEAPI(ref RestClient restClient, RestRequest restRequest, string url, string jsonBody, ExtentTest test)
        {
            try
            {
                restClient = new RestClient(url);
                restRequest = new RestRequest(Method.PUT);
                restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
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
        public static RestRequest RequestPATCHAPI(ref RestClient restClient, RestRequest restRequest, string url, string jsonBody, ExtentTest test)
        {

            try
            {
                restClient = new RestClient(url);
                restRequest = new RestRequest(Method.PATCH);
                restRequest.AddParameter("application/json-patch+json", jsonBody, ParameterType.RequestBody);
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
                string statusDesc = restResponse.StatusDescription;
                numericStatusCode = (int)statusCode;
                ExtentReportsHelper.LogMessage(test, "Status Code = " + numericStatusCode + " -> Status Message = " + statusDesc);

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
                ExtentReportsHelper.LogMessage(test, " \r\nJSON RESPONSE : " + json);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

        }

        //Gets ouput json object
        public static List<T> OutputJsonResponse<T>(IRestResponse restResponse, ExtentTest test)
        {
            List<T> objOutputParams = default(List<T>);
            try
            {
                string json = restResponse.Content;
                objOutputParams = JSONHelperMethods.DeserializeJson<List<T>>(json);
                ExtentReportsHelper.LogMessage(test, " \r\nJSON RESPONSE : " + json);
                return objOutputParams;
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }
            return objOutputParams;
        }

        #endregion
    }
}

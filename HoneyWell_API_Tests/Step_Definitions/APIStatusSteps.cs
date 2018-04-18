using AventStack.ExtentReports;
using HoneyWell_API_Tests.DataFields;
using HoneyWell_API_Tests.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace HoneyWell_API_Tests.Step_Definitions
{
    [Binding]
    public class APIStatusSteps
    {
        #region ---Variables---
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        private AuthenticationParameters authParams;
        private string reportTest;
        #endregion

        #region --- BDD Conditions---

        #region @Given
        [Given(@"The credentials for post type are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheCredentialsForPostTypeAreAnd(string username, string password, string grant_type)
        {
            try
            {
                if (!username.Equals(""))
                {
                    reportTest = "Username : " + username;
                    authParams = new AuthenticationParameters();
                    authParams.UserName = username;
                    //authParams.Password = Encryption.EncodePasswordToBase64(password);
                    authParams.Password = password;
                    authParams.Grant_Type = grant_type;
                }
            }
            catch(Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }
        }
       
        [Given(@"I want to know the Status Code of the api with ""(.*)"" and ""(.*)""")]
        public void GivenIWantToKnowTheStatusCodeOfTheApiWithAnd(string type, string url)
        {
            try
            {
                LogTraceListener.LastGherkinMessage = type + " API : " + url + " | \r\n" + reportTest;

                switch (type.ToUpper())
                {
                    case "POST":
                        string json = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestPOSTAPI(ref restClient, restRequest, url, json, test);
                        break;
                    case "GET":
                        restRequest = APIHelperMethods.RequestGETAPI(ref restClient, restRequest, url, test);
                        break;
                    case "UPDATE":
                        restRequest = APIHelperMethods.RequestUPDATEAPI(ref restClient, restRequest, url, test);
                        break;
                    case "DELETE":
                        restRequest = APIHelperMethods.RequestDELETEAPI(ref restClient, restRequest, url, test);
                        break;
                    case "PATCH":
                        restRequest = APIHelperMethods.RequestPATCHAPI(ref restClient, restRequest, url, test);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }


        }
        #endregion

        #region @When
        [When(@"I hit the request on the api")]
        public void WhenIHitTheRequestOnTheApi()
        {
            try
            {
                restResponse = restClient.Execute(restRequest);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }
        }
        #endregion

        #region @Then
        [Then(@"the system should return (.*)")]
        public void ThenTheSystemShouldReturn(int expectedCode)
        {
            try
            {
                int numericStatusCode = APIHelperMethods.StatusCode(restResponse,test);

                if (numericStatusCode == expectedCode)
                {
                    APIHelperMethods.SaveJSONResponse(restResponse,test);
                }
                OTAAssert.AssertEquals(test, numericStatusCode, expectedCode, "Status Code = " + numericStatusCode);
            }
            catch (Exception e)
            {
                ExtentReportsHelper.PrintException(test, e);
            }

        }
        #endregion

        #endregion
    }
}
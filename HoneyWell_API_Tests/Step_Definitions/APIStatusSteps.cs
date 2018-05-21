using AventStack.ExtentReports;
using HoneyWellAPITests.DataFields;
using HoneyWellAPITests.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace HoneyWellAPITests.Step_Definitions
{
    [Binding]
    public class APIStatusSteps
    {
        #region ---Variables---
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        private PostAuthParams authParams;
        private string reportTest;
        #endregion

        #region --- BDD Conditions---

        #region TC01

        #region @Given
        [Given(@"The credentials for ""(.*)"" type are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheCredentialsForTypeAreAnd(string type, string username, string password, string grant_type)
        {
            try
            {
                switch (type.ToUpper())
                {
                    case "POST":
                        reportTest = "Username : " + username;
                        authParams = new PostAuthParams();
                        authParams.UserName = username;
                        //authParams.Password = Encryption.EncodePasswordToBase64(password);
                        authParams.Password = password;
                        authParams.Grant_Type = grant_type;
                        JSONHelperMethods.WriteToJsonFile(ScenarioContext.Current.ScenarioInfo.Title, authParams, test);
                        break;
                    case "GET":
                        break;
                    case "UPDATE":
                        break;
                    case "DELETE":
                        break;
                    case "PATCH":
                        reportTest = "Username : " + username;
                        authParams = new PostAuthParams();
                        authParams.UserName = username;
                        //authParams.Password = Encryption.EncodePasswordToBase64(password);
                        authParams.Password = password;
                        authParams.Grant_Type = grant_type;
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

        [Given(@"I want to know the Status Code of the api with ""(.*)"" and ""(.*)""")]
        public void GivenIWantToKnowTheStatusCodeOfTheApiWithAnd(string type, string url)
        {
            try
            {
                ExtentReportsHelper.LogMessage(test, type + " API : " + url);
                ExtentReportsHelper.LogMessage(test, reportTest);

                switch (type.ToUpper())
                {
                    case "POST":
                        string json_post = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestPOSTAPI(ref restClient, restRequest, url, json_post, test);
                        break;
                    case "GET":
                        restRequest = APIHelperMethods.RequestGETAPI(ref restClient, restRequest, url, test);
                        break;
                    case "UPDATE":
                        string json_put = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestUPDATEAPI(ref restClient, restRequest, url, json_put, test);
                        break;
                    case "DELETE":
                        restRequest = APIHelperMethods.RequestDELETEAPI(ref restClient, restRequest, url, test);
                        break;
                    case "PATCH":
                        string json_patch = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestPATCHAPI(ref restClient, restRequest, url, json_patch, test);
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
       
        [When(@"ScenarioOld_I hit the request on the api")]
        public void WhenScenarioOld_IHitTheRequestOnTheApi()
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
                PostAuthParams param = JSONHelperMethods.ReadFromJsonFile<PostAuthParams>(ScenarioContext.Current.ScenarioInfo.Title);
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

        #endregion TC01

    }
}
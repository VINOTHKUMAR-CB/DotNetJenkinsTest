using AventStack.ExtentReports;
using HoneyWellAPITests.DataFields;
using HoneyWellAPITests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HoneyWellAPITests.Features
{
    [Binding]
    public class StatusOfAPIsSteps
    {
        #region ---Variables---
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        private InputParameters inputParams;
        #endregion

        #region ---BDD Conditions---

        #region ---Given---

        [Given(@"User reads input parameter  from  input ""(.*)"" Json File with ""(.*)""")]
        public void GivenUserReadsInputParameterFromInputJsonFileWith(string JsonInputFileName, string Tag)
        {
            try
            {
                inputParams = JSONHelperMethods.ReadFromJsonFile<InputParameters>(JsonInputFileName);
                ExtentReportsHelper.LogMessage(test, "Test Case ID : " + Tag);

                switch (inputParams.type.ToUpper())
                {
                    case "POST":
                        JsonBodyParameters postparams = new JsonBodyParameters();
                        {
                            postparams.dealerId = inputParams.dealerId;
                            postparams.dealerName = inputParams.dealerName;
                            postparams.locationId = inputParams.locationId;
                            postparams.aliase = inputParams.aliase;
                            postparams.contactPerson = inputParams.contactPerson;
                            postparams.email = inputParams.email;
                            postparams.contactNumber = inputParams.contactNumber;
                            postparams.location = inputParams.location;
                            postparams.address = inputParams.address;
                            postparams.city = inputParams.city;
                            postparams.status = inputParams.status;
                            postparams.partitionKey = inputParams.partitionKey;
                        }
                        ExtentReportsHelper.LogMessage(test, inputParams.type + " API : " + inputParams.url);
                        string json_post = JsonConvert.SerializeObject(postparams);
                        ExtentReportsHelper.LogMessage(test, "Dealer Id : " + postparams.dealerId + " & Dealer Name : " + postparams.dealerName);
                        restRequest = APIHelperMethods.RequestPOSTAPI(ref restClient, restRequest, inputParams.url, json_post, test);
                        break;
                    case "GET":
                        ExtentReportsHelper.LogMessage(test, inputParams.type + " API : " + inputParams.url + inputParams.dealerId);
                        restRequest = APIHelperMethods.RequestGETAPI(ref restClient, restRequest, inputParams.url + inputParams.dealerId, test);
                        break;
                    case "UPDATE":
                        JsonBodyParameters putparams = new JsonBodyParameters();
                        {
                            putparams.dealerId = inputParams.dealerId;
                            putparams.dealerName = inputParams.dealerName;
                            putparams.locationId = inputParams.locationId;
                            putparams.aliase = inputParams.aliase;
                            putparams.contactPerson = inputParams.contactPerson;
                            putparams.email = inputParams.email;
                            putparams.contactNumber = inputParams.contactNumber;
                            putparams.location = inputParams.location;
                            putparams.address = inputParams.address;
                            putparams.city = inputParams.city;
                            putparams.status = inputParams.status;
                            putparams.partitionKey = inputParams.partitionKey;
                        }
                        ExtentReportsHelper.LogMessage(test, inputParams.type + " API : " + inputParams.url + putparams.dealerId);
                        string json_put = JsonConvert.SerializeObject(putparams);
                        restRequest = APIHelperMethods.RequestUPDATEAPI(ref restClient, restRequest, inputParams.url + putparams.dealerId, json_put, test);
                        break;
                    case "DELETE":
                        restRequest = APIHelperMethods.RequestDELETEAPI(ref restClient, restRequest, inputParams.url, test);
                        break;
                    case "PATCH":
                        //string json_patch = JsonConvert.SerializeObject(authParams);
                        //restRequest = APIHelperMethods.RequestPATCHAPI(ref restClient, restRequest, param.url, json_patch, test);
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

        #region ---When---
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

        #region ---Then---

        [Then(@"the system should  return expected status code")]
        public void ThenTheSystemShouldReturnExpectedStatusCode()
        {
            try
            {
                int numericStatusCode = APIHelperMethods.StatusCode(restResponse, test);
                List<InputParameters> outputresponse = APIHelperMethods.OutputJsonResponse<InputParameters>(restResponse, test);

                Assert.Multiple(() =>
                {
                    OTAAssert.AssertEquals(test, numericStatusCode, inputParams.Expected_statuscode, "Status Code = " + numericStatusCode);
                    foreach (var item in outputresponse)
                    {
                        OTAAssert.AssertEquals(test, item.dealerId, inputParams.dealerId, "Dealer Id = " + item.dealerId);
                    }
                });

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





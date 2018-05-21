using AventStack.ExtentReports;
using HoneyWell_API_Tests.DataFields;
using HoneyWell_API_Tests.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HoneyWell_API_Tests.Step_Definitions
{
    class Stepjson
    {
        #region ---Variables---
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        private AuthenticationParameters authParams;
        private string reportTest;
        #endregion

        #region TC02

        [Given(@"User reads input parameter  from  input ""(.*)"" Json File")]
        public void GivenUserReadsInputParameterFromInputJsonFile(string p0)
        {


            AuthenticationParameters param = JSON_HelperMethods.ReadFromJsonFile<AuthenticationParameters>(p0);
            try
            {
                ExtentReportsHelper.LogMessage(test, param.type + " API : " + param.url);
                ExtentReportsHelper.LogMessage(test, reportTest);

                switch (param.type.ToUpper())
                {
                    case "POST":
                        string json = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestPOSTAPI(ref restClient, restRequest, param.url, json, test);
                        break;
                    case "GET":
                        restRequest = APIHelperMethods.RequestGETAPI(ref restClient, restRequest, param.url, test);
                        break;
                    case "UPDATE":
                        restRequest = APIHelperMethods.RequestUPDATEAPI(ref restClient, restRequest, param.url, test);
                        break;
                    case "DELETE":
                        restRequest = APIHelperMethods.RequestDELETEAPI(ref restClient, restRequest, param.url, test);
                        break;
                    case "PATCH":
                        string json_patch = JsonConvert.SerializeObject(authParams);
                        restRequest = APIHelperMethods.RequestPATCHAPI(ref restClient, restRequest, param.url, json_patch, test);
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

        #endregion TC02

    }
}

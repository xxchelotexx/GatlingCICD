using System;
using System.Net;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD.Tests
{
    [Binding]
    public class GetProductsStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"I have a the Gatling enpoint")]
        public void GivenIHaveATheGatlingEnpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("product/", Method.Get);
        }

        [When(@"I send a GET request,")]
        public void WhenISendAGETRequest()
        {
            response = client.ExecuteGet(request);
        }


        [Then(@"I spect a valid response")]
        public void ThenISpectAValidResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

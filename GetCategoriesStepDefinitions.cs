using System;
using System.Net;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetCategoriesStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"I have a valid endpoint for categories")]
        public void GivenIHaveAValidEndpointForCategories()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/", Method.Get);
        }

        [When(@"a GET request is sent")]
        public void WhenAGETRequestIsSent()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I spect a valid response\.")]
        public void ThenISpectAValidResponse_()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

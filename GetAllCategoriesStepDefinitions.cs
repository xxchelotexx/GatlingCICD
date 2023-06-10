using System;
using System.Net;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetAllCategoriesStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"I have a categories endpoin")]
        public void GivenIHaveACategoriesEndpoin()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/", Method.Get);
        }

        [When(@"I send a GET request")]
        public void WhenISendAGETRequest()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I spect  a valid response")]
        public void ThenISpectAValidResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

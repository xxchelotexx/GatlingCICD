using System;
using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetSpecificIDStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
       

        [Given(@"Given I have a Valid product ID")]
        public void GivenGivenIHaveAValidProductID()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("product/{postid}", Method.Get);
        }

        [When(@"I send a Get request")]
        public void WhenISendAGetRequest()
        {
            request.AddUrlSegment("postid", 17);
            response = client.ExecuteGet(request);

        }

        [Then(@"I Spect a Valid Response")]
        public void ThenISpectAValidResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            
        }
    }
}

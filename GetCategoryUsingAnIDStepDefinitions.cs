using System;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetCategoryUsingAnIDStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        Random random;
        int first;
        int last;
        int categoryID;
        JObject jsonObject;

        [Given(@"I Have a valid category endpoint")]
        public void GivenIHaveAValidCategoryEndpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/{categoryID}", Method.Get);
        }

        [Given(@"a valid category ID,")]
        public void GivenAValidCategoryID()
        {
            first = CategoryID.Categories("first");
            last = CategoryID.Categories("last");
            Random random = new Random();
            categoryID = random.Next(first, last);
            request.AddUrlSegment("categoryID", categoryID);
        }

        [When(@"I send a GET  request")]
        public void WhenISendAGETRequest()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I spect a valid response with the category data")]
        public void ThenISpectAValidResponseWithTheCategoryData()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            jsonObject = JObject.Parse(response.Content);
            Assert.That((int)jsonObject["id"], Is.TypeOf<int>());
            Assert.That((string)jsonObject["name"], Is.TypeOf<string>());
            Assert.That((string)jsonObject["slug"], Is.TypeOf<string>());
            Assert.That((int)jsonObject["sorting"], Is.TypeOf<int>());
        }
    }
}

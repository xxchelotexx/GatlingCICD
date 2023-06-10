using System;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetCategoryByIDStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        int first;
        int last;
        int productID;
        JObject jsonObject;

        [Given(@"I have a category endpoint")]
        public void GivenIHaveACategoryEndpoin()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/{categoryID}", Method.Get);
        }

        [Given(@"a valid ID")]
        public void GivenAValidID()
        {
            var first = CategoryID.Categories("first");
            var last = CategoryID.Categories("last");
            Random random = new Random();
            var categoryID = random.Next(first, last);
            request.AddUrlSegment("categoryID", categoryID);
        }

        [When(@"I send a GET Request")]
        public void WhenISendAGETRequest()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I spect a valid response with valid data")]
        public void ThenISpectAValidResponseWithValidData()
        {
            var content = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Console.WriteLine(content);
            var jsonObject = JObject.Parse(response.Content);
            Assert.That((int)jsonObject["id"], Is.TypeOf<int>());
            Assert.That((string)jsonObject["name"], Is.TypeOf<string>());
            Assert.That((string)jsonObject["slug"], Is.TypeOf<string>());
            Assert.That((int)jsonObject["sorting"], Is.TypeOf<int>());
        }
    }
}

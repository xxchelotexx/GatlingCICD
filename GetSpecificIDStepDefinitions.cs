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
        Random random;
        int first;
        int last;
        int productID = 17;
        JObject jsonObject;

       

        [Given(@"I have a Valid product ID")]
        public void GivenGivenIHaveAValidProductID()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("product/{productID}", Method.Get);
            first = ProductID.Product("first");
            last = ProductID.Product("last");
            random = new Random();
            productID = random.Next(first,last);
            Console.WriteLine(productID);

        }

        [When(@"I send a Get request")]
        public void WhenISendAGetRequest()
        {
            request.AddUrlSegment("productID", productID);
            response = client.ExecuteGet(request);

        }

        [Then(@"I Spect a Valid Response")]
        public void ThenISpectAValidResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            jsonObject = JObject.Parse(response.Content);
            Assert.That((string)jsonObject["name"], Is.TypeOf<string>());
            Assert.That((string)jsonObject["description"], Is.TypeOf<string>());
            Assert.That((double)jsonObject["price"], Is.TypeOf<double>());
            Assert.That((int)jsonObject["categoryId"], Is.TypeOf<int>());

        }
    }
}

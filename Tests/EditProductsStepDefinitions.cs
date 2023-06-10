using System;
using System.Net;
using System.Threading.Channels;
using GatlingCICD.tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD.Tests
{
    [Binding]
    public class EditProductsStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        int editedCategory;
        double editedPrice;
        string editedName;
        string editedDescription;
        object body;
        string item;
        int first;
        int last;
        int putid;
        JObject jsonObject;
        string authToken;
        Random random;

        [Given(@"I have a valid endpoint")]
        public void GivenIHaveAValidEndpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("product/{putid}", Method.Put);
            random = new Random();
            first = ProductID.Product("first");
            last = ProductID.Product("last");
            putid = random.Next(first, last);
            request.AddUrlSegment("putid", putid);
        }

        [Given(@"I have the data to edit a product")]
        public void GivenIHaveTheDataToEditAProduct()
        {
            authToken = GetToken.TokenGenerator();
            Console.WriteLine(authToken);
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddHeader("Content-Type", "application/json");
            random = new Random();
            first = CategoryID.Categories("first");
            last = CategoryID.Categories("last");
            editedCategory = random.Next(first, last);
            editedPrice = Math.Round(random.NextDouble() * 100, 2);
            editedName = RandomStringGenerator.GenerateRandomString(5);
            editedDescription = RandomStringGenerator.GenerateRandomString(6);

            body = new ProductBody { name = editedName, description = editedDescription, categoryId = editedCategory, price = editedPrice };
            Console.WriteLine(body);
            item = JsonConvert.SerializeObject(body);
            Console.WriteLine(item);

        }

        [When(@"a PUT request is sent")]
        public void WhenAPUTRequestIsSent()
        {
            request.AddParameter("application/json", item, ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"I spect a valid response with the data changed")]
        public void ThenTheChangesOfTheProduct_()
        {
            jsonObject = JObject.Parse(response.Content);
            Console.WriteLine(jsonObject);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(jsonObject["name"].ToString() == editedName, Is.EqualTo(true));
            Assert.That(jsonObject["description"].ToString() == editedDescription, Is.EqualTo(true));
            Assert.That((double)jsonObject["price"], Is.EqualTo(editedPrice));
            Assert.That((int)jsonObject["categoryId"], Is.EqualTo(editedCategory));
        }
    }
}

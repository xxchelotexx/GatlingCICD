using System;
using System.Net;
using GatlingRestSharp;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class CreateAProductStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        Random random;
        int first;
        int last;
        int productID;
        int newCategory;
        double newPrice;
        string newName;
        string newDescription;
        object body;
        string item;
        string authToken;
        JObject jsonObject;

        [Given(@"I have the product creation endpoint")]
        public void GivenIHaveTheProductCreationEndpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("product/", Method.Post);
            authToken = GetToken.TokenGenerator();
            Console.WriteLine(authToken);
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddHeader("Content-Type", "application/json");

        }

        [Given(@"valid data")]
        public void GivenValidData()
        {
            Random random = new Random();
            first = CategoryID.Categories("first");
            last = CategoryID.Categories("last");
            newCategory = random.Next(first, last);
            newPrice = Math.Round(random.NextDouble() * 100, 2);
            newName = RandomStringGenerator.GenerateRandomString(5);
            newDescription = RandomStringGenerator.GenerateRandomString(6);
            body = new ProductBody { name = newName, description = newDescription, categoryId = newCategory, price = newPrice };
            item = System.Text.Json.JsonSerializer.Serialize(body);
            request.AddParameter("application/json", item, ParameterType.RequestBody);

        }

        [When(@"I send a POST request,")]
        public void WhenISendAPOSTRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"I receive a valid response with the new product data")]
        public void ThenIReceiveAValidResponseWithTheNewProductData()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            Console.WriteLine(jsonObject.ToString());
            Assert.That(jsonObject["name"].ToString() , Is.EqualTo(newName));
            Assert.That(jsonObject["description"].ToString() , Is.EqualTo(newDescription));
            Assert.That((double)jsonObject["price"], Is.EqualTo(newPrice));
            Assert.That((int)jsonObject["categoryId"], Is.EqualTo(newCategory));
        }
    }
}

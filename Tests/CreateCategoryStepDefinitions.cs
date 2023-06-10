using System;
using System.Net;
using GatlingCICD.tools;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD.Tests
{
    [Binding]
    public class CreateCategoryStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        Random random;
        int first;
        int last;
        int categoryID;
        string editedName;
        string item;
        string newCategoryName;
        object body;
        string authToken;
        JObject jsonObject;

        [Given(@"I have a valid Category endpoint")]
        public void GivenIHaveAValidCategoryEndpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/", Method.Post);
        }

        [Given(@"valid data to create a category")]
        public void GivenValidDataToCreateACategory()
        {
            authToken = GetToken.TokenGenerator();
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddHeader("Content-Type", "application/json");
            newCategoryName = RandomStringGenerator.GenerateRandomString(5);
            body = new ProductBody { name = newCategoryName };
            item = System.Text.Json.JsonSerializer.Serialize(body);
            Console.WriteLine(item);
            request.AddParameter("application/json", item, ParameterType.RequestBody);
        }

        [When(@"I  send a POST request")]
        public void WhenISendAPOSTRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"I spect a valid response and the new category data\.")]
        public void ThenISpectAValidResponseAndTheNewCategoryData_()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            Console.WriteLine(jsonObject.ToString());
            Assert.That(jsonObject["name"].ToString() == newCategoryName, Is.EqualTo(true));
            Assert.That((int)jsonObject["id"], Is.TypeOf<int>());
            Assert.That((int)jsonObject["sorting"], Is.TypeOf<int>());
        }
    }
}

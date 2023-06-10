using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using System.Net;
using Newtonsoft.Json;
using GatlingCICD.tools;

namespace GatlingCICD.Tests
{


    [Binding]
    public class EditCategoryStepDefinitions
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
        object body;
        string authToken;
        JObject jsonObject;

        [Given(@"I have a valid category endpoint")]
        public void GivenIHaveAValidCategoryEndpoint()
        {
            client = new RestClient("http://demostore.gatling.io/api/");
            request = new RestRequest("category/{categoryID}", Method.Put);


        }

        [Given(@"I have a valid ID")]
        public void GivenIHaveAValidID()
        {
            first = CategoryID.Categories("first");
            last = CategoryID.Categories("last");
            Random random = new Random();
            categoryID = random.Next(first, last);
            Console.WriteLine(categoryID);
            request.AddUrlSegment("categoryID", categoryID);
        }

        [Given(@"I have valid data\.")]
        public void GivenIHaveValidData_()
        {
            authToken = GetToken.TokenGenerator();
            Console.WriteLine(authToken);
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddHeader("Content-Type", "application/json");
            editedName = RandomStringGenerator.GenerateRandomString(5);
            body = new ProductBody { name = editedName };
            item = System.Text.Json.JsonSerializer.Serialize(body);

        }

        [When(@"I send a PUT request,")]
        public void WhenISendAPUTRequest()
        {
            request.AddParameter("application/json", item, ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"I spect a valid response and the data edited\.")]
        public void ThenISpectAValidResponseAndTheDataEdited_()
        {
            response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            jsonObject = JObject.Parse(response.Content);
            Console.WriteLine(jsonObject.ToString());
            Assert.That((int)jsonObject["id"], Is.TypeOf<int>());
            Assert.That((string)jsonObject["name"], Is.EqualTo(editedName));
        }
    }
}

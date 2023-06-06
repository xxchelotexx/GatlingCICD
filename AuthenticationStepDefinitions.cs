using System;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        object body;
        string item;
        JObject jsonObject;
        string authToken;

        [Given(@"I authenticate using valid credentials")]
        public void GivenIAuthenticateUsingValidCredentials()
        {
            client = new RestClient("http://demostore.gatling.io/api/authenticate");
            request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            body = new Authenticate { username = "admin", password = "admin" };
            item = System.Text.Json.JsonSerializer.Serialize(body);


        }

        [When(@"I send a POST request")]
        public void WhenISendAPOSTRequest()
        {
            request.AddParameter("application/json", item, ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"I receive a valid response and a valid Token")]
        public void ThenIReceiveAValidResponseAndAValidToken()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            jsonObject = JObject.Parse(response.Content);
            authToken = jsonObject["token"].ToString();
            Console.WriteLine(authToken);
            Assert.That(!string.IsNullOrEmpty(authToken), Is.EqualTo(true));
        }
    }
}

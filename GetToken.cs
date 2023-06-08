using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GatlingCICD
{
    public class GetToken
    {

        public static string TokenGenerator() 
        {
            var client = new RestClient("http://demostore.gatling.io/api/authenticate");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var body = new Credentials { username = "admin", password = "admin" };
            var item = System.Text.Json.JsonSerializer.Serialize(body);
            request.AddParameter("application/json", item, ParameterType.RequestBody);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            var token = jsonObject["token"].ToString();
            
            return token;
        }
        
    }
}

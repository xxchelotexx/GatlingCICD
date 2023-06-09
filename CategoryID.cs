using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace GatlingCICD
{
    public class CategoryID
    {
        public static int Categories(string position) 
        {
            var client = new RestClient("http://demostore.gatling.io/api/");
            var request = new RestRequest("category/", Method.Get);
            var response = client.ExecuteGet(request);
            var content = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var idsObject = JsonConvert.DeserializeObject<dynamic[]>(response.Content);
            var idsArray = idsObject.Select(obj => (int)obj.id).ToArray();
            var id = 0;

            if (position == "first")
            {
                id = idsArray.First();
            }
            else id = idsArray.Last();

            return id;
        }
    }
}

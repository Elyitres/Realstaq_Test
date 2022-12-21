using Newtonsoft.Json;
using Realstaq.Const;
using Realstaq.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace Realstaq.API
{
    public class HousesApi
    {
        public List<House> GetHouses(double price_gte = 0, double price_lte = 0, string city = null)
        {
            
            RestClient client = new RestClient(ApiEndpoint.HousesEndpoint);
            RestRequest restRequest = new RestRequest();
            restRequest.AddQueryParameter("price_gte", price_gte.ToString().Replace(",", "."));
            restRequest.AddQueryParameter("price_lte", price_lte.ToString().Replace(",", "."));
            restRequest.AddQueryParameter("city", city);
            RestResponse response = client.Get(restRequest);

            var jsonString = response.Content;
            return JsonConvert.DeserializeObject<List<House>>(jsonString);
        }

        public HttpStatusCode ReturnResponseStatusCode(double price_gte = 0, double price_lte = 0, string city = "")
        {
            RestClient client = new RestClient(ApiEndpoint.HousesEndpoint);
            RestRequest restRequest = new RestRequest();
            restRequest.AddQueryParameter("price_gte", price_gte.ToString().Replace(",", "."));
            restRequest.AddQueryParameter("price_lte", price_lte.ToString().Replace(",", "."));
            restRequest.AddQueryParameter("city", city);
            RestResponse response = client.Execute(restRequest);

            return response.StatusCode;
        }

        public List<House> FilterHouses(string price_gte = "", string price_lte = "", string city = "")
        {

            RestClient client = new RestClient(ApiEndpoint.HousesEndpoint);
            RestRequest restRequest = new RestRequest();
            restRequest.AddQueryParameter("price_gte", price_gte);
            restRequest.AddQueryParameter("price_lte", price_lte);
            restRequest.AddQueryParameter("city", city);
            RestResponse response = client.Get(restRequest);

            var jsonString = response.Content;
            return JsonConvert.DeserializeObject<List<House>>(jsonString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using AlaskaXC.Models;
using AlaskaXC.Services.Interface;
using AlaskaXC.Helpers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;

namespace AlaskaXC.Services.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient _client;
        private List<FlightModel> flightList;

        public FlightService()
        {
            _client = new HttpClient();
        }

        public async Task<List<FlightModel>> GetFlightData()
        {
            //    var uri = new Uri(string.Format(Strings.FlightApiUrl, "0", "60"));
            //    _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Strings.OcpApimSubscriptionKey);
            //    var response = await _client.GetAsync(uri);
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        flightList = JsonConvert.DeserializeObject<List<FlightModel>>(content);
            //    }

            //    return flightList;
            //}

            //public async Task NewTask()
            //{
            try
            {


                HttpClient client = new HttpClient();
             var url = new Uri(string.Format(Strings.FlightApiUrl, "0", "60"));
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Strings.OcpApimSubscriptionKey);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(string.Format(Strings.FlightApiUrl, "0", "60")),
                    Method = HttpMethod.Get,
                };
               // request.Headers.Add("Ocp-Apim-Subscription-Key", Strings.OcpApimSubscriptionKey);
                var response = await _client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<FlightModel>>(responseString);
                    return model;
                }
                //else if (response.StatusCode == HttpStatusCode.Unauthorized)
                //{
                //    // you need to maybe re-authenticate here
                //    return default(T);
                //}
                //else
                //{
                //    return default(T);
                //}
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
    }
}
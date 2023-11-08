using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace ApiDemo
{
    public class HttpClientDemo
    {
        public static async Task CallAPI(String urlString, String data, HttpRequestType method = HttpRequestType.GET)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                if (method == HttpRequestType.POST)
                {
                    httpClient = HttpClientDemo.WriteDataToBody(httpClient, data);
                }

                HttpResponseMessage response = await httpClient.GetAsync(urlString);


                if (response.IsSuccessStatusCode)
                {
                    // Process successful response
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("response is success: {0}", content.ToString());

                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Handle 404 Not Found
                    throw new ApplicationException("404 Not found.");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Handle 401 Unauthorized
                    throw new ApplicationException("Unauthorized");
                }
                else
                {
                    // Add more error handling as required
                    Console.WriteLine("Global error in response: ", response.StatusCode);

                }

                // Release client from memory
                httpClient.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Request failed: ", exception.Message);
            }
        }

        private static HttpClient WriteDataToBody(HttpClient client, String dataString)
        {
            var data = new StringContent(dataString, Encoding.UTF8, "application/json");

            return client;
        }

        // Adding headers for user authentication
        private static HttpClient AuthorizeRequest(HttpClient client, String token = "123123123")
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            return client;
        }

    }


    public class Hero
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("localized_name")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("primary_attr")]
        public string PrimaryAttribute { get; set; }

        [JsonPropertyName("attack_type")]
        public string AttackType { get; set; }

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }


    public class HeroService
    {
        private readonly HttpClient _httpClient;

        public HeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Hero>> GetHeroesAsync()
        {
            var response = await _httpClient.GetAsync("https://api.opendota.com/api/heroes");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

           // Console.WriteLine("response is success: {0}", content.ToString());

            //var heroes = new List<Hero> { new Hero() };
            var heroes = JsonSerializer.Deserialize<List<Hero>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return heroes;
        }
    }
}
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ApiDemo
{
    public class HttpClientDemo
    {
        public static async void CallAPI(String urlString, String data, HttpRequestType method = HttpRequestType.GET)
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
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("response is success: ", responseContent);

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
}
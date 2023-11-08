using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo
{
    public enum HttpRequestType
    {
        GET, POST, DELETE, UPDATE
    }

    public class WebRequestDemo
    {

        public static void CallAPI(String urlString, String data, HttpRequestType method = HttpRequestType.GET)
        {
            Uri url = new Uri(urlString);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";

            // Only for POST methods, to write data to request body 
            if (method == HttpRequestType.POST)
            {
                request = WebRequestDemo.WriteDataToBody(request, data);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
        }

        private static HttpWebRequest WriteDataToBody(HttpWebRequest request, String data)
        {
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Method = "POST";

            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(data);
            }
            return request;
        }
    }
}

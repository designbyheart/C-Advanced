using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.CompilerServices;

namespace ApiDemo
{

    public enum HttpRequestType
    {
        GET, POST, DELETE, UPDATE
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string data = @"{""email"":""designbyheart@gmail.com"", ""password"":""$2y$10$5X4BtDG4wRVfIWiT1I2wB.6GlFNz2WzQO/oDq53r6JXeIf7fMv7NW""}";

            string urlString = "https://api.opendota.com/api/heroes";
            HttpClientDemo.CallAPI(urlString, data);
        }

    }
}

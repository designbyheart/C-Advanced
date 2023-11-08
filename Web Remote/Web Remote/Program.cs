using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace ApiDemo
{
    public class Program
    {
        static async Task Main()
        {
            string data = @"{""email"":""designbyheart@gmail.com"", ""password"":""$2y$10$5X4BtDG4wRVfIWiT1I2wB.6GlFNz2WzQO/oDq53r6JXeIf7fMv7NW""}";

            string urlString = "https://api.opendota.com/api/heroes/";
            //  string urlString = "https://localhost:7179/WeatherForecast";
            // HttpClientDemo.CallAPI(urlString, data);
             WebRequestDemo.CallAPI(urlString, "");
            
           /*
            using (var httpClient = new HttpClient())
            {
                var heroService = new HeroService(httpClient);
                var heroes = await heroService.GetHeroesAsync();
                foreach (var hero in heroes)
                {
                    Console.WriteLine($"ID: {hero.Id}, Name: {hero.Name}, Localized Name: {hero.LocalizedName}");
                }
            }*/
        }

    }
}

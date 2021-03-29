using AutiAssist_Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace AutiAssist_Mobile.Services
{
    class CoffeeInternetDataService
    {
        static string BaseURL = "https://motzcoffee.azurewebsites.net";
        static HttpClient client;
        static Random random;
        static CoffeeInternetDataService()
        {
            random = new Random();

            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
        }

        public static async Task AddCoffee(string name, string roaster)
        {
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image,
                Id = random.Next(0, 1000000)
            };

            var json = JsonConvert.SerializeObject(coffee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Coffee", content);

            if(!response.IsSuccessStatusCode)
            {

            }
        }
        public static async Task RemoveCoffee(int id)
        {
            var response = await client.DeleteAsync($"api/Coffee/{id}");

            if (!response.IsSuccessStatusCode)
            {

            }
        }
        public static async Task<IEnumerable<Coffee>> GetCoffee()
        {
            var json = await client.GetStringAsync("api/Coffee");
            var coffees = JsonConvert.DeserializeObject<IEnumerable<Coffee>>(json);
            return coffees;
        }
    }
}

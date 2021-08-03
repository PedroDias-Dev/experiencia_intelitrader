using IntelitraderMobile.Models;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace IntelitraderMobile.Services
{
    public class APIUserService : IUserService
    {
        readonly List<User> items;

        //private readonly HttpClient _httpClient;

        HttpClient _httpClient = new HttpClient();

        //public APIUserService(HttpClient httpClient)
            //:base()
        //{
           // _httpClient = httpClient;
        //}

        public async Task AddUser(User item)
        {
            Console.WriteLine(item);

            var response = await _httpClient.PostAsync("http://10.0.2.2:5001/api/User",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUser(string id, User item)
        {
            var response = await _httpClient.PutAsync($"http://10.0.2.2:5001/api/User/" + id,
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(string id)
        {
            var response = await _httpClient.DeleteAsync($"http://10.0.2.2:5001/api/User/" + id);

            response.EnsureSuccessStatusCode();
        }

        public async Task<User> GetUser(string id)
        {
            var response = await _httpClient.GetAsync($"http://10.0.2.2:5001/api/User/" + id);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(responseAsString);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _httpClient.GetAsync("http://10.0.2.2:5001/api/User");
            System.Console.WriteLine(response);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<User>>(responseAsString);
        }
    }
}
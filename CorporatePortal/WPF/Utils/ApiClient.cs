using CorporatePortal.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace CorporatePortal.WPF.Utils
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string url)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(url) };
        }

        public async Task<User> AuthorizeUserAsync(string username, string password)
        {
            var loginRequest = new LoginDto
            {
                Username = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/users/authorize", content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        public async Task<User> GetUserAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/users/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }
        public async Task<List<Department>> GetDepartmentAsync()
        {
            var response = await _httpClient.GetAsync("api/Departments");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Department>>(content);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/users", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/users/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("api/users");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(content);
        }
        public async Task<List<Event>> GetEventsAsync()
        {
            var response = await _httpClient.GetAsync("api/Events");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Event>>(content);

        }

        public async Task<IEnumerable<News>> GetNewsAsync()
        {
            var response = await _httpClient.GetAsync("api/News");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<News>>(content);
        }

        public async Task<NewsItem> CreateNewsAsync(NewsItem newsItem)
        {
            var json = JsonConvert.SerializeObject(newsItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/news", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode} and message: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NewsItem>(responseContent);
        }
        public async Task<EventsItem> CreateEventAsync(EventsItem eventDto)
        {
            var json = JsonConvert.SerializeObject(eventDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/events", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode} and message: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EventsItem>(responseContent);
        }

        public async Task<IEnumerable<EventType>> GetEventTypesAsync()
        {
            var response = await _httpClient.GetAsync("api/events/eventtypes");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<EventType>>(responseContent);
        }

        public async Task<IEnumerable<EventStatus>> GetEventStatusesAsync()
        {
            var response = await _httpClient.GetAsync("api/events/eventstatuses");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<EventStatus>>(responseContent);
        }

        public async Task<IEnumerable<NewType>> GetNewsTypesAsync()
        {
            var response = await _httpClient.GetAsync("api/news/newstypes");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<NewType>>(responseContent);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/users/{userId}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        internal async Task<IEnumerable<UserPosition>> GetPositionsAsync()
        {
            var response = await _httpClient.GetAsync("api/users/Positions");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode} and message: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UserPosition>>(responseContent);
        }
    }
}

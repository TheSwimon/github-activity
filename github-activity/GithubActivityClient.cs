using github_activity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace github_activity
{
    public class GithubActivityClient
    {
        private readonly HttpClient _httpClient;

        public GithubActivityClient()
        {
            _httpClient = new HttpClient();
        }

        
        public async Task<List<GithubEvent>> GetGithubActivity(string username)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
                var url = $"https://api.github.com/users/{username}/events";
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                List<GithubEvent>? events = JsonSerializer.Deserialize<List<GithubEvent>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                return events ?? new List<GithubEvent>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<GithubEvent>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<GithubEvent>();
            }
        }
    }
}



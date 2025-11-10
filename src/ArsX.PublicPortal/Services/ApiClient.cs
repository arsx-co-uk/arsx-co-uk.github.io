using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArsX.PublicPortal.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Removed hardcoded BaseAddress to use the application's configured base address
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GET request failed: {ex.Message}");
                return default;
            }
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResponse>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POST request failed: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> PostAsync<T>(string url, T payload)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, payload);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POST request failed: {ex.Message}");
                return false;
            }
        }
    }
}
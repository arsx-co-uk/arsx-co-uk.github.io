using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Client.ApiClients
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime? JSRuntime;

        public ApiClient(HttpClient httpClient, IJSRuntime? jsRuntime)
        {
            _httpClient = httpClient;
            JSRuntime = jsRuntime;
        }

        public async Task<UserInfo> GetUserInfo()
        {
            // [ArsX:Phase1Patch]
            if (JSRuntime != null && await JSRuntime.InvokeAsync<bool>("Boolean", "window.__ARSX_API__"))
            {
                var result = await JSRuntime.InvokeAsync<JsonElement>("window.__ARSX_API__.whoami");
                var userInfo = JsonSerializer.Deserialize<UserInfo>(result.GetRawText());
                if (userInfo == null)
                {
                    throw new InvalidOperationException("Failed to deserialize user info from the fake API.");
                }
                return userInfo;
            }

            var response = await _httpClient.GetAsync("api/userinfo");
            response.EnsureSuccessStatusCode();

            var userInfoFromApi = await response.Content.ReadFromJsonAsync<UserInfo>();
            if (userInfoFromApi == null)
            {
                throw new InvalidOperationException("Failed to deserialize user info from the API response.");
            }
            return userInfoFromApi;
        }
    }

    public class UserInfo
    {
        public string User { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
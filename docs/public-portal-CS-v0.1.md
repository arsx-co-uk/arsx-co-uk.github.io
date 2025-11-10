# ArsX Public Portal v0.1

## Code Overview

### SessionStore.cs
```csharp
using System;

namespace ArsX.PublicPortal.Services
{
    public class SessionStore
    {
        public string? JwtToken { get; private set; }
        public string? DPoPKey { get; private set; }

        public event EventHandler? OnSessionChanged;

        public void SetSession(string jwtToken, string dPoPKey)
        {
            JwtToken = jwtToken;
            DPoPKey = dPoPKey;
            OnSessionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ClearSession()
        {
            JwtToken = null;
            DPoPKey = null;
        }

        public bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(JwtToken) && !string.IsNullOrEmpty(DPoPKey);
        }
    }
}
```

### CsrfService.cs
```csharp
using System;
using System.Security.Cryptography;

namespace ArsX.PublicPortal.Services
{
    public class CsrfService
    {
        private string? _csrfToken;

        public string GetOrCreateToken()
        {
            if (string.IsNullOrEmpty(_csrfToken))
            {
                _csrfToken = GenerateToken();
            }

            return _csrfToken;
        }

        public void InvalidateToken()
        {
            _csrfToken = null;
        }

        private string GenerateToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenData = new byte[32];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }
    }
}
```

### ApiClient.cs
```csharp
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System;

namespace ArsX.PublicPortal.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime? JSRuntime;

        public ApiClient(HttpClient httpClient, IJSRuntime? jsRuntime = null)
        {
            _httpClient = httpClient;
            JSRuntime = jsRuntime;
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

        public async Task<UserInfo> GetUserInfo()
        {
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
        public string? Name { get; set; }
        public string? Email { get; set; }
        // Add other properties as needed
    }
}
```

### Program.cs
```csharp
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArsX.PublicPortal;
using ArsX.PublicPortal.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<SessionStore>();
builder.Services.AddScoped<CsrfService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001") });

builder.Services.AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>(provider =>
{
    var contentTypeProvider = new FileExtensionContentTypeProvider();
    contentTypeProvider.Mappings[".png"] = "image/png";
    return contentTypeProvider;
});

await builder.Build().RunAsync();
```
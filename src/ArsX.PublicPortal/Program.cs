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

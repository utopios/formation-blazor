using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using demo_blazor_webassembly;
using demo_blazor_webassembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient());
builder.Services.AddScoped<ICorrectPriceService, RandomCorrectPriceService>();
builder.Services.AddScoped<GetPhotoFromApiService>();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<Random>(sp => new Random());
await builder.Build().RunAsync();
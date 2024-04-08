using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using demo_blazor_webassembly;
using demo_blazor_webassembly.Services;
using demo_blazor_webassembly.Tools;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddApiServices();

builder.Services.AddScoped<ICorrectPriceService, RandomCorrectPriceService>();
builder.Services.AddScoped<GetPhotoFromApiService>();

builder.Services.AddScoped<Random>(sp => new Random());
await builder.Build().RunAsync();
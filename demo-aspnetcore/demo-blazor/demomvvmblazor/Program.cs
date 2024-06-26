using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using demomvvmblazor;
using demomvvmblazor.Services;
using demomvvmblazor.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<GenerateurMotService>();

builder.Services.AddTransient(sp => new HttpClient());


builder.Services.AddScoped<FoodFactsViewModel>();
builder.Services.AddScoped<LePenduViewModel>();

await builder.Build().RunAsync();
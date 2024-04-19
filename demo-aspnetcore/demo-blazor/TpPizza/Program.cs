using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TpPizza;
using TpPizza.Services;
using TpPizza.Tools;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddViewsModels();

builder.Services.AddCustomServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationDataMemoryStorage>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<FormationAuthenticationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<FormationAuthenticationProvider>());
builder.Services.AddAuthorizationCore();


// builder.Services.AddAuthorizationCore(builder =>
// {
//     builder.AddPolicy();
// })

await builder.Build().RunAsync();
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DemoAuthenticationAuthorization;
using DemoAuthenticationAuthorization.Service;
using DemoAuthenticationAuthorization.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider, TrainingAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthorizationHandler, AdultRequirementHandler>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("admin", policy => policy.RequireRole("admin"));
    config.AddPolicy("Adult", policy => policy.AddRequirements(new AdultRequirement()));
});

await builder.Build().RunAsync();
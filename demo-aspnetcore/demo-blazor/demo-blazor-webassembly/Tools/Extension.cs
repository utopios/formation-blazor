using demo_blazor_webassembly.Services;

namespace demo_blazor_webassembly.Tools;

public static class Extension
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ApiService>();
        services.AddTransient(sp => new HttpClient());
    }
}
using TpPizza.Services;
using TpPizza.ViewModels;

namespace TpPizza.Tools;

public static class Extension
{
    public static void AddViewsModels(this IServiceCollection services)
    {
        services.AddScoped<PizzasViewModel>();
    }
    
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IPizzaService, FakePizzaDbService>();
        services.AddScoped<IPanierService, PanierService>();
    }
}
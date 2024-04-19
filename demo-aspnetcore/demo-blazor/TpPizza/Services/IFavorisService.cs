using Microsoft.AspNetCore.Components;
using TpPizza.Models;

namespace TpPizza.Services;

public interface IFavorisService : IAsyncDisposable
{
    public Task<List<Pizza>> GetFavoris();

    public Task AddPizza(Pizza pizza, ElementReference elementReference);

    public Task RemovePizza(Pizza pizza);
}
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TpPizza.Models;

namespace TpPizza.Services;

public class LocalStorageFavorisService : IFavorisService
{

    private readonly IJSRuntime _jsRuntime;
    private Lazy<IJSObjectReference> _accessorJsRef = new();

    public LocalStorageFavorisService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<List<Pizza>> GetFavoris()
    {
        await AwaitReference();
        var result = await _accessorJsRef.Value.InvokeAsync<string>("get", "favoris");
        return  JsonSerializer.Deserialize<List<Pizza>>(result) ?? new List<Pizza>();
    }

    public async Task AddPizza(Pizza pizza, ElementReference elementReference)
    {
        await AwaitReference();
        var oldPizza = await GetFavoris();
        oldPizza.Add(pizza);
        await _accessorJsRef.Value.InvokeVoidAsync("set","favoris",  JsonSerializer.Serialize(oldPizza), elementReference);
    }

    public async  Task RemovePizza(Pizza pizza)
    {
        await AwaitReference();
        var oldPizza = await GetFavoris();
        oldPizza.Remove(oldPizza.First(p => p.Id == pizza.Id));
        await _accessorJsRef.Value.InvokeVoidAsync("set", oldPizza);
    }
    
    private async Task AwaitReference()
    {
        _accessorJsRef = new (await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/localstorageaccessor.js"));
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }
}
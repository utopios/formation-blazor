using System.Net.Http.Json;
using demo_blazor_webassembly.DTOs;

namespace demo_blazor_webassembly.Services;

public class ApiService
{
    private HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<FoodFacts?> Get(string code)
    {
        return _httpClient.GetFromJsonAsync<FoodFacts>($"product/{code}.json");
    }
}
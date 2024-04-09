using System.Net.Http.Json;
using demomvvmblazor.Models;

namespace demomvvmblazor.Services;

public class ApiService
{
    private HttpClient _httpClient;
    private string baseURL = "https://world.openfoodfacts.org/api/v2/";

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseURL);
    }

    public Task<FoodFacts?> Get(string code)
    {
        return _httpClient.GetFromJsonAsync<FoodFacts>($"product/{code}.json");
    }
}
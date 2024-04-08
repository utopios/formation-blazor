using System.Text.Json.Serialization;

namespace demo_blazor_webassembly.DTOs;

public class FoodFacts
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    [JsonPropertyName("product")]
    public Product Product { get; set; }
}
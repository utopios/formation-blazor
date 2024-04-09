using System.Text.Json.Serialization;

namespace demo_blazor_webassembly.DTOs;

public class Product
{
    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }
    
    [JsonPropertyName("_keywords")]
    public List<string> KeyWords { get; set; }
}
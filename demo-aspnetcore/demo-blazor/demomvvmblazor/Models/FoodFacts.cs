using System.Text.Json.Serialization;

namespace demomvvmblazor.Models;

public class FoodFacts
{
    
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    [JsonPropertyName("product")]
    public Product Product { get; set; }

    public FoodFacts()
    {
        Product = new Product();
    }
}
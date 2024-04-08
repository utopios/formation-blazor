using Microsoft.AspNetCore.Components;

namespace demo_blazor_webassembly.Services;

public class RandomCorrectPriceService : ICorrectPriceService
{
    private int price;

    private Random _random;
    private NavigationManager _navigationManager;
    
    public RandomCorrectPriceService(Random random, NavigationManager navigationManager)
    {
        _random = random;
        price = _random.Next(100);
        _navigationManager = navigationManager;
    }


    public string TryPrice(int price)
    {
        if (this.price < price)
        {
            return "Plus petit";
        }
        else if (this.price > price)
        {
            return "Plus Grand";
        }
        else
        {
            _navigationManager.NavigateTo("/counter");
            return "Bravo";
        }
    }
}
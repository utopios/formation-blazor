namespace demo_blazor_webassembly.Services;

public class RandomCorrectPriceService : ICorrectPriceService
{
    private int price;

    private Random _random;
    
    public RandomCorrectPriceService()
    {
        _random = new Random();
        price = _random.Next(100);
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
            return "Bravo";
        }
    }
}
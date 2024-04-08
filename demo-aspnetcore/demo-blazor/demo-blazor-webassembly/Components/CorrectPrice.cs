using demo_blazor_webassembly.Services;
using Microsoft.AspNetCore.Components;

namespace demo_blazor_webassembly.Components;

public partial class CorrectPrice
{
    [Inject]
    private ICorrectPriceService _CorrectPriceService { get; set; }

    public CorrectPrice()
    {
        
    }
    // public CorrectPrice(ICorrectPriceService correctPriceService)
    // {
    //     _CorrectPriceService = correctPriceService;
    // }
    public int Price { get; set; }
    public string Message { get; set; }
    
    public void IsCorrect()
    {
        
        Message = _CorrectPriceService.TryPrice(Price);

    }
}
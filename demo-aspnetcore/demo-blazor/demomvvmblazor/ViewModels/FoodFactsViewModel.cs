using System.ComponentModel;
using System.Runtime.CompilerServices;
using demomvvmblazor.Models;
using demomvvmblazor.Services;

namespace demomvvmblazor.ViewModels;

public class FoodFactsViewModel : INotifyPropertyChanged
{
    public string Code
    {
        get => FoodFacts.Code; 
        set => FoodFacts.Code = value;
    }
    public string ProductName { 
        get => FoodFacts.Product.ProductName; 
    }
    
    public List<string> KeyWords { get => FoodFacts.Product.KeyWords; }

    private FoodFacts FoodFacts;
    private ApiService _apiService;
    
    public FoodFactsViewModel(ApiService apiService)
    {
        FoodFacts = new FoodFacts();
        _apiService = apiService;
    }
    public async void SearchProduct()
    {
        FoodFacts = await _apiService.Get(Code);
        OnPropertyChanged("ProductName");
        OnPropertyChanged("KeyWords");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}
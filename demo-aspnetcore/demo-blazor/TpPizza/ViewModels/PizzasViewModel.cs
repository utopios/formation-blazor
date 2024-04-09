using System.ComponentModel;
using System.Runtime.CompilerServices;
using TpPizza.Models;
using TpPizza.Services;

namespace TpPizza.ViewModels;

public class PizzasViewModel : INotifyPropertyChanged
{
    private IPanierService _panierService;
    
    public Panier Panier { get; } 
    
    public PizzasViewModel(IPanierService panierService)
    {
        _panierService = panierService;
        _panierService.MiseAJouerPanierEvent += () =>
        {
            OnPropertyChanged("Panier");
        };
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}
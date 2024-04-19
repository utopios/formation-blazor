using System.ComponentModel;
using System.Runtime.CompilerServices;
using TpPizza.Models;
using TpPizza.Services;

namespace TpPizza.ViewModels;

public class PizzasViewModel : INotifyPropertyChanged
{
    private IPanierService _panierService;
    private IPizzaService _pizzaService;
    
    public Panier Panier { get; } 
    
    public List<PizzaPanier> PizzaPaniers
    {
        get => Panier.Pizzas;
    }

    public decimal Total
    {
        get => Panier.Total;
    }
    
    public List<Pizza> Pizzas { get; }
    
    public PizzasViewModel(IPanierService panierService, IPizzaService pizzaService)
    {
        _panierService = panierService;
        Panier = _panierService.Panier;
        _pizzaService = pizzaService;
        Pizzas = _pizzaService.GetAll();
        _panierService.MiseAJouerPanierEvent += () =>
        {
            OnPropertyChanged("Panier");
            
            OnPropertyChanged("PizzaPaniers");
            OnPropertyChanged("Total");
        };
        
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}
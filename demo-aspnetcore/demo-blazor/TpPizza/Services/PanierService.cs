using TpPizza.Models;

namespace TpPizza.Services;

public class PanierService : IPanierService
{
    private Panier _panier;
    
    public Panier Panier
    {
        get => _panier;
    }

    public PanierService()
    {
        _panier = new Panier();
    }
    public event Action? MiseAJouerPanierEvent;
    public void AjouterAuPanier(Pizza pizza)
    {
        bool isExist = false;
        foreach(PizzaPanier p in _panier.Pizzas)
        {
            if (p.Pizza.Id == pizza.Id)
            {
                p.Qty++;
                isExist = true;
                break;
            }
        }

        if (!isExist)
        {
            _panier.Pizzas.Add(new PizzaPanier() {Pizza = pizza, Qty = 1});
        }
        
        MiseAJouerPanierEvent?.Invoke();
    }

    public void SupprimerDuPanier(Pizza pizza)
    {
        bool toDelete = true;
        foreach(PizzaPanier p in _panier.Pizzas)
        {
            if (p.Pizza.Id == pizza.Id)
            {
                if (p.Qty > 0)
                {
                    p.Qty--;
                    toDelete = false;
                    break;
                }
            }
        }
        if (toDelete)
        {
            _panier.Pizzas.Remove(_panier.Pizzas.First(p => p.Pizza.Id == pizza.Id));
        }
        
        MiseAJouerPanierEvent?.Invoke();
    }
}
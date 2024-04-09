namespace TpPizza.Models;

public class Panier
{
    public List<PizzaPanier> Pizzas { get; set; }

    public decimal Total
    {
        get
        {
            decimal total = 0;
            Pizzas.ForEach(p =>
            {
                total += p.Pizza.Price * p.Qty;
            });
            return total;
        }
    }
    public Panier()
    {
        Pizzas = new List<PizzaPanier>();
    }
}
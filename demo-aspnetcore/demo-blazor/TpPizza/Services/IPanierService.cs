using TpPizza.Models;

namespace TpPizza.Services;

public interface IPanierService
{
    public event Action MiseAJouerPanierEvent;

    public void AjouterAuPanier(Pizza pizza);
    public void SupprimerDuPanier(Pizza pizza);

}
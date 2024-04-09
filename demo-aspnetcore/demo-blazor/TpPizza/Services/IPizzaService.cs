using TpPizza.Models;

namespace TpPizza.Services;

public interface IPizzaService
{
    public Pizza? Get(int id);
    public List<Pizza> GetAll();
    public bool Post(Pizza pizza);
    public bool Put(Pizza pizza);
    public bool Delete(int id);
}
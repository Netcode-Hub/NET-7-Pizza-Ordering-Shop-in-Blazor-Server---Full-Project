using PizzaLogic.DataModels;
using PizzaLogic.Models;

namespace PizzaBayServer.Services
{
    public interface IService
    {
        Task<Response> AddPizza(Pizza model);
        Task<List<Pizza>> GetPizzas();
        Task<Pizza> GetPizza(int id);
        Task<Response> DeletePizza(int id);
    }
}

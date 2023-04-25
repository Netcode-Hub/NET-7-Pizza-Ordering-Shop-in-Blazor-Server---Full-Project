using PizzaLogic.DataModels;

namespace PizzaBay.Services
{
    public interface IOrderService
    {
        event Action OnChange;
        int Count { get; set; }
        Task<Response> AddOrder(OrderModel model);
        Task<int> RefreshCount();
        Task<List<MyOrdersModel>> GetOrders();
        Task<Response> DeleteOrder(int id);
    }
}

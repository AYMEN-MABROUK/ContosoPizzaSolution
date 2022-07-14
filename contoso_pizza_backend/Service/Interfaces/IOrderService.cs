using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Services.Interfaces
{
    public interface IOrderService
    {

        public Task<IEnumerable<Order>> GetOrders();
        public Task<Order> GetOrder(long Id);

        public Task<Order> AddOrder(OrderDTO orderDTO);
        public Task<Order> UpdateOrder(OrderDTO orderDTO);
        public Task<bool> RemoveOrder(long Id);
    
    }
}
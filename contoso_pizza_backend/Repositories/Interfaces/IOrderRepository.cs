using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public long getMaxId();
    }
}
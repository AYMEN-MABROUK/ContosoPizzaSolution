using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Repositories.Interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        public long getMaxId();
    }
}
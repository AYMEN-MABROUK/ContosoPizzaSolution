using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public long getMaxId();
    }
}
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;

namespace contoso_pizza_backend.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }

        Task<bool> Complete();
    }
}
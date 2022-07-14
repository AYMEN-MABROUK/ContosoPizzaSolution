using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Services.Interfaces
{
    public interface ICustomerService
    {

        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(long Id);

        public Task<Customer> AddCustomer(CustomerDTO customerDTO);
        public Task<Customer> UpdateCustomer(CustomerDTO CustomerDTO);
        public Task<bool> RemoveCustomer(long Id);
    
    }
}
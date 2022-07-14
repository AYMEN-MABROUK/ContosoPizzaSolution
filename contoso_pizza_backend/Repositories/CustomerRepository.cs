using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;
using contoso_pizza_backend.Data;

namespace contoso_pizza_backend.Repositories
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        private readonly ContosoPizzaContext _context;
        public CustomerRepository(ContosoPizzaContext context) : base(context)
        {
            _context = context;
        }

        public long getMaxId()
        {
            var customer = _context.Customers.OrderByDescending(c => c.Id).FirstOrDefault();
            if(customer == null){return 0;}
            return customer.Id;
        }

        
    }
}
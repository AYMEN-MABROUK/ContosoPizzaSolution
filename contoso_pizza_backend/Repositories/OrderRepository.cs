using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;
using contoso_pizza_backend.Data;

namespace contoso_pizza_backend.Repositories
{
    public class OrderRepository : Repository<Order>,IOrderRepository
    {
        private readonly ContosoPizzaContext _context;
        public OrderRepository(ContosoPizzaContext context) : base(context)
        {
            _context = context;
        }

        public long getMaxId()
        {
            var order = _context.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
            if(order == null){return 0;}
            return order.Id;
        }

        
    }
}
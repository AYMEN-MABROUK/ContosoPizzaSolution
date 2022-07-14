using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;
using contoso_pizza_backend.Data;

namespace contoso_pizza_backend.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>,IOrderDetailRepository
    {
        private readonly ContosoPizzaContext _context;
        public OrderDetailRepository(ContosoPizzaContext context) : base(context)
        {
            _context = context;
        }

        public long getMaxId()
        {
            var orderDetail = _context.OrderDetails.OrderByDescending(oDetail => oDetail.Id).FirstOrDefault();
            if(orderDetail == null){return 0;}
            return orderDetail.Id;
        }

        
    }
}
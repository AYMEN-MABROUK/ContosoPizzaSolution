using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;
using contoso_pizza_backend.Data;

namespace contoso_pizza_backend.Repositories
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ContosoPizzaContext _context;
        public ProductRepository(ContosoPizzaContext context) : base(context)
        {
            _context = context;
        }

        public long getMaxId()
        {
            var product = _context.Products.OrderByDescending(p => p.Id).FirstOrDefault();
            if(product == null){return 0;}
            return product.Id;
        }
        
    }
}
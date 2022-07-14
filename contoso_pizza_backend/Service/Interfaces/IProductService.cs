using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Services.Interfaces
{
    public interface IProductService
    {

        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(long Id);

        public Task<Product> AddProduct(ProductDTO productDTO);
        public Task<Product> UpdateProduct(ProductDTO productDTO);
        public Task<bool> RemoveProduct(long Id);
    
    }
}
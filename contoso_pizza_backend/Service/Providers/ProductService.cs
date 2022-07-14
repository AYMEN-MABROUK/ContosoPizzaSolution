using AutoMapper;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Services.Interfaces;
using contoso_pizza_backend.UnitOfWork;
using contoso_pizza_backend.Helpers;

namespace contoso_pizza_backend.Services.Providers
{

    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(
            ILogger<ProductService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public async Task<Product> AddProduct (ProductDTO productDTO)
        {
            var maxId = _unitOfWork.ProductRepository.getMaxId();
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            product.Id = ++maxId;

            _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.Complete();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetProduct(long Id)
        {
            var product =await _unitOfWork.ProductRepository.Find(p => p.Id == Id );

            if (product == null)
            {
                throw new ApplicationNotFoundException("Product not found");
            }
            return product;
            
        }

        public async Task<bool> RemoveProduct(long Id)
        {
            var productToRemove = await _unitOfWork.ProductRepository.Find(p => p.Id == Id);

            if(productToRemove == null)
            {
                throw new ApplicationNotFoundException("Product not founnd");
            }

            _unitOfWork.ProductRepository.Delete(productToRemove);
            
            var success = await _unitOfWork.Complete();
            if(!success)
            {
                throw new ApplicationValidationException("Error deleting Product");
            }
            return success;
        }

        public async Task<Product> UpdateProduct(ProductDTO productDTO)
        {
            var productToUpdate = _mapper.Map<ProductDTO, Product>(productDTO);

            if (!await ProductExists(productToUpdate))
            {
                throw new ApplicationNotFoundException("Product not found ");
            }
            
            _unitOfWork.ProductRepository.Update(productToUpdate);

            var success = await _unitOfWork.Complete();
            if (!success)
            {
                throw new ApplicationValidationException("Error updating product");
            }
            return productToUpdate;
        }

        private async Task<bool> ProductExists(Product product)
        {
            var result = await _unitOfWork.ProductRepository.Find(p => p.Id == product.Id);
            return (result != null);
        }
    }

}
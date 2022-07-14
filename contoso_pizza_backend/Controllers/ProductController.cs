using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using contoso_pizza_backend.Models;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.DTO.Response;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Services.Interfaces;

namespace contoso_pizza_backend.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController( IProductService productService )
        {
            _productService = productService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            HttpContext.Items.Add("action","Product.GetProducts");
            var products = await _productService.GetProducts(); 
            return Ok(products.ToList());
 
        }

        [HttpGet("{Id}")]  
        public async Task<ActionResult> GetProduct(long Id)
        {
            HttpContext.Items.Add("action","Product.GetProduct");
            var product = await _productService.GetProduct(Id);
            return Ok(product);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDTO productDTO)
        {
            HttpContext.Items.Add("action","Product.AddProduct");
            var productAdded = await _productService.AddProduct(productDTO);
            return Ok(productAdded);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDTO productDTO)
        {
            HttpContext.Items.Add("action","Product.UpdateProduct");
            var productUpdated = await _productService.UpdateProduct(productDTO);
            return Ok(productUpdated);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProduct(long Id)
        {
            HttpContext.Items.Add("action","Product.DeleteProduct");
            var product = await _productService.RemoveProduct(Id);
            return Ok(new ResponseSuccess("Product Deleted", "Product.DeleteProduct"));
        }

    }
    
}
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController( ICustomerService customerService )
        {
            _customerService = customerService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            HttpContext.Items.Add("action","Customer.GetCustomers");
            var customers = await _customerService.GetCustomers(); 
            return Ok(customers.ToList());
 
        }

        [HttpGet("{Id}")]  
        public async Task<ActionResult> GetCustomer(long Id)
        {
            HttpContext.Items.Add("action","Customer.GetCustomer");
            var customer = await _customerService.GetCustomer(Id);
            return Ok(customer);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            HttpContext.Items.Add("action","Customer.AddCustomer");
            var customerAdded = await _customerService.AddCustomer(customerDTO);
            return Ok(customerAdded);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO customerDTO)
        {
            HttpContext.Items.Add("action","Customer.UpdateCustomer");
            var customerUpdated = await _customerService.UpdateCustomer(customerDTO);
            return Ok(customerUpdated);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCustomer(long Id)
        {
            HttpContext.Items.Add("action","Customer.DeleteCustomer");
            var customer = await _customerService.RemoveCustomer( Id);
            return Ok(new ResponseSuccess("Customer Deleted", "Customer.CustomerCategory"));
        }

    }
    
}
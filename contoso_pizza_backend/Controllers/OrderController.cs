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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController( IOrderService orderService )
        {
            _orderService = orderService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            HttpContext.Items.Add("action","Order.GetOrders");
            var orders = await _orderService.GetOrders(); 
            return Ok(orders.ToList());
 
        }

        [HttpGet("{Id}")]  
        public async Task<ActionResult> GetOrder(long Id)
        {
            HttpContext.Items.Add("action","Order.GetOrder");
            var order = await _orderService.GetOrder(Id);
            return Ok(order);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddOrder(OrderDTO orderDTO)
        {
            HttpContext.Items.Add("action","Order.AddOrder");
            var orderAdded = await _orderService.AddOrder(orderDTO);
            return Ok(orderAdded);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(OrderDTO orderDTO)
        {
            HttpContext.Items.Add("action","Order.UpdateOrder");
            var orderUpdated = await _orderService.UpdateOrder(orderDTO);
            return Ok(orderUpdated);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteOrder(long Id)
        {
            HttpContext.Items.Add("action","Order.DeleteOrder");
            var order = await _orderService.RemoveOrder(Id);
            return Ok(new ResponseSuccess("Order Deleted", "Order.DeleteOrder"));
        }

    }
    
}
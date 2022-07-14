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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController( IOrderDetailService orderDetailService )
        {
            _orderDetailService = orderDetailService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            HttpContext.Items.Add("action","OrderDetail.GetOrderDetails");
            var orderDetails = await _orderDetailService.GetOrderDetails(); 
            return Ok(orderDetails.ToList());
 
        }

        [HttpGet("{Id}")]  
        public async Task<ActionResult> GetOrderDetail(long Id)
        {
            HttpContext.Items.Add("action","OrderDetail.GetOrderDetail");
            var orderDetail = await _orderDetailService.GetOrderDetail(Id);
            return Ok(orderDetail);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            HttpContext.Items.Add("action","OrderDetail.AddOrderDetail");
            var orderDetailAdded = await _orderDetailService.AddOrderDetail(orderDetailDTO);
            return Ok(orderDetailAdded);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            HttpContext.Items.Add("action","OrderDetail.UpdateOrderDetail");
            var orderDetailUpdated = await _orderDetailService.UpdateOrderDetail(orderDetailDTO);
            return Ok(orderDetailUpdated);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteOrderDetail(long Id)
        {
            HttpContext.Items.Add("action","Order.DeleteOrderDetail");
            var order = await _orderDetailService.RemoveOrderDetail(Id);
            return Ok(new ResponseSuccess("Order Deleted", "Order.DeleteOrderDetail"));
        }

    }
    
}
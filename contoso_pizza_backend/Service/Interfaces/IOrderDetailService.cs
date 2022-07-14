using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;

namespace contoso_pizza_backend.Services.Interfaces
{
    public interface IOrderDetailService
    {

        public Task<IEnumerable<OrderDetail>> GetOrderDetails();
        public Task<OrderDetail> GetOrderDetail(long Id);

        public Task<OrderDetail> AddOrderDetail(OrderDetailDTO orderDetailDTO);
        public Task<OrderDetail> UpdateOrderDetail(OrderDetailDTO orderDetailDTO);
        public Task<bool> RemoveOrderDetail(long Id);
    
    }
}
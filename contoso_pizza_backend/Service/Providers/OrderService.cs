using AutoMapper;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Services.Interfaces;
using contoso_pizza_backend.UnitOfWork;
using contoso_pizza_backend.Helpers;

namespace contoso_pizza_backend.Services.Providers
{

    public class OrderService : IOrderService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public OrderService(
            ILogger<OrderService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public async Task<Order> AddOrder (OrderDTO orderDTO)
        {
            var maxId = _unitOfWork.OrderRepository.getMaxId();
            var order = _mapper.Map<OrderDTO, Order>(orderDTO);
            order.Id = ++maxId;

            //verify if customer exist
            var customerFound = await _unitOfWork.CustomerRepository.Find(c => c.Id == order.CustomerId);

            if (customerFound == null)
            {
                throw new ApplicationNotFoundException("customer not found");
            }

            _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.Complete();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _unitOfWork.OrderRepository.GetAll();
        }

        public async Task<Order> GetOrder(long Id)
        {
            var order =await _unitOfWork.OrderRepository.Find(o => o.Id == Id );

            if (order == null)
            {
                throw new ApplicationNotFoundException("Order not found");
            }
            return order;
            
        }

        public async Task<bool> RemoveOrder(long Id)
        {
            var orderToRemove = await _unitOfWork.OrderRepository.Find(o => o.Id == Id);

            if(orderToRemove == null)
            {
                throw new ApplicationNotFoundException("order not founnd");
            }

            _unitOfWork.OrderRepository.Delete(orderToRemove);
            
            var success = await _unitOfWork.Complete();
            if(!success)
            {
                throw new ApplicationValidationException("Error deleting order");
            }
            return success;
        }

        public async Task<Order> UpdateOrder(OrderDTO orderDTO)
        {
            var orderToUpdate = _mapper.Map<OrderDTO, Order>(orderDTO);

            if (!await OrderExists(orderToUpdate))
            {
                throw new ApplicationNotFoundException("order not found ");
            }
            
            _unitOfWork.OrderRepository.Update(orderToUpdate);

            var success = await _unitOfWork.Complete();
            if (!success)
            {
                throw new ApplicationValidationException("Error updating order");
            }
            return orderToUpdate;
        }

        private async Task<bool> OrderExists(Order order)
        {
            var result = await _unitOfWork.OrderRepository.Find(o => o.Id == order.Id);
            return (result != null);
        }
    }

}
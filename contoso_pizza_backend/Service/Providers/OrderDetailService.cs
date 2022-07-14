using AutoMapper;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Services.Interfaces;
using contoso_pizza_backend.UnitOfWork;
using contoso_pizza_backend.Helpers;

namespace contoso_pizza_backend.Services.Providers
{

    public class OrderDetailService : IOrderDetailService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<OrderDetailService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public OrderDetailService(
            ILogger<OrderDetailService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public async Task<OrderDetail> AddOrderDetail (OrderDetailDTO orderDetailDTO)
        {
            var maxId = _unitOfWork.OrderDetailRepository.getMaxId();
            var orderDetail = _mapper.Map<OrderDetailDTO, OrderDetail>(orderDetailDTO);
            orderDetail.Id = ++maxId;

            //verify if order and product exist
            var orderFound = await _unitOfWork.OrderRepository.Find(o => o.Id == orderDetail.OrderId);
            var productFound = await _unitOfWork.ProductRepository.Find(p => p.Id == orderDetail.ProductId);

            if (orderFound == null || productFound == null )
            {
                throw new ApplicationNotFoundException("order or product not found");
            }

            _unitOfWork.OrderDetailRepository.Add(orderDetail);
            await _unitOfWork.Complete();
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _unitOfWork.OrderDetailRepository.GetAll();
        }

        public async Task<OrderDetail> GetOrderDetail(long Id)
        {
            var orderDetail =await _unitOfWork.OrderDetailRepository.Find(oDetail => oDetail.Id == Id );

            if (orderDetail == null)
            {
                throw new ApplicationNotFoundException("OrderDetail not found");
            }
            return orderDetail;
            
        }

        public async Task<bool> RemoveOrderDetail(long Id)
        {
            var orderDetailToRemove = await _unitOfWork.OrderDetailRepository.Find(oDetail => oDetail.Id == Id);

            if(orderDetailToRemove == null)
            {
                throw new ApplicationNotFoundException("orderDetail not founnd");
            }

            _unitOfWork.OrderDetailRepository.Delete(orderDetailToRemove);
            
            var success = await _unitOfWork.Complete();
            if(!success)
            {
                throw new ApplicationValidationException("Error deleting orderDetail");
            }
            return success;
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var orderDetailToUpdate = _mapper.Map<OrderDetailDTO, OrderDetail>(orderDetailDTO);

            if (!await OrderDetailExists(orderDetailToUpdate))
            {
                throw new ApplicationNotFoundException("orderDetail not found ");
            }
            
            _unitOfWork.OrderDetailRepository.Update(orderDetailToUpdate);

            var success = await _unitOfWork.Complete();
            if (!success)
            {
                throw new ApplicationValidationException("Error updating orderDetail");
            }
            return orderDetailToUpdate;
        }

        private async Task<bool> OrderDetailExists(OrderDetail orderDetail)
        {
            var result = await _unitOfWork.OrderRepository.Find(oDetail => oDetail.Id == orderDetail.Id);
            return (result != null);
        }
    }

}
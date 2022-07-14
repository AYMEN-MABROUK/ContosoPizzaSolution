using AutoMapper;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Services.Interfaces;
using contoso_pizza_backend.UnitOfWork;
using contoso_pizza_backend.Helpers;

namespace contoso_pizza_backend.Services.Providers
{

    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public CustomerService(
            ILogger<CustomerService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public async Task<Customer> AddCustomer (CustomerDTO customerDTO)
        {
            var maxId = _unitOfWork.CustomerRepository.getMaxId();
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            customer.Id = ++maxId;

            _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Complete();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _unitOfWork.CustomerRepository.GetAll();
        }

        public async Task<Customer> GetCustomer(long Id)
        {
            var customer =await _unitOfWork.CustomerRepository.Find(c => c.Id == Id );

            if (customer == null)
            {
                throw new ApplicationNotFoundException("customer not found");
            }
            return customer;
            
        }

        public async Task<bool> RemoveCustomer(long Id)
        {
            var customerToRemove = await _unitOfWork.CustomerRepository.Find(c => c.Id == Id);

            if(customerToRemove == null)
            {
                throw new ApplicationNotFoundException("customer not founnd");
            }

            _unitOfWork.CustomerRepository.Delete(customerToRemove);
            
            var success = await _unitOfWork.Complete();
            if(!success)
            {
                throw new ApplicationValidationException("Error deleting customer");
            }
            return success;
        }

        public async Task<Customer> UpdateCustomer(CustomerDTO customerDTO)
        {
            var customerToUpdate = _mapper.Map<CustomerDTO, Customer>(customerDTO);

            if (!await CustomerExists(customerToUpdate))
            {
                throw new ApplicationNotFoundException("customer not found ");
            }
            
            _unitOfWork.CustomerRepository.Update(customerToUpdate);

            var success = await _unitOfWork.Complete();
            if (!success)
            {
                throw new ApplicationValidationException("Error updating customer");
            }
            return customerToUpdate;
        }

        private async Task<bool> CustomerExists(Customer customer)
        {
            var result = await _unitOfWork.CustomerRepository.Find(c => c.Id == customer.Id);
            return (result != null);
        }
    }

}
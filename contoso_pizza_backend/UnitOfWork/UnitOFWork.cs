using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Repositories.Interfaces;
using contoso_pizza_backend.Data;
using contoso_pizza_backend.Repositories;

namespace contoso_pizza_backend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContosoPizzaContext context;
        private readonly IConfiguration config;
        public UnitOfWork(ContosoPizzaContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        private ICustomerRepository customerRepository = null;

        public ICustomerRepository CustomerRepository 
        => customerRepository ?? new CustomerRepository(context);

        private IOrderRepository orderRepository = null;

        public IOrderRepository OrderRepository 
        => orderRepository ?? new OrderRepository(context);

        private IOrderDetailRepository orderDetailRepository = null;

        public IOrderDetailRepository OrderDetailRepository 
        => orderDetailRepository ?? new OrderDetailRepository(context);

        private IProductRepository productRepository = null;

        public IProductRepository ProductRepository 
        => productRepository ?? new ProductRepository(context);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
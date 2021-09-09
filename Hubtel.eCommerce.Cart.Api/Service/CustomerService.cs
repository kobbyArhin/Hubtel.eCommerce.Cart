using Hubtel.eCommerce.Cart.Api.Model.GenericRepository.Repository;
using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryReadOnly _iRepository;
        public CustomerService(IRepositoryReadOnly iRepository)
        {
            _iRepository = iRepository;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            var customers = await _iRepository.GetAllAsync<Customer>();
            return customers.ToList();
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var customer = await _iRepository.GetOneAsync<Customer>(p => p.CustomerId == customerId);
            return customer;
        }
    }
}

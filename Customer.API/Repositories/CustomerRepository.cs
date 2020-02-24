using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.API.Contexts;
using Customer.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly CustomerInfoDbContext context_;

        public CustomerRepository(CustomerInfoDbContext context)
        {
            context_ = context;
        }

        public Task<List<CustomerDto>> GetCustomersAsync()
        {
            return context_.Customers.ToListAsync();
        }

        public Task<CustomerDto> GetCustomerAsync(int customerId)
        {
            return context_.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                throw new ArgumentNullException(nameof(customerDto));
            }

            var result = (await context_.AddAsync(customerDto)).Entity;

            if (await context_.SaveChangesAsync() > 0)
            {
                return result;
            }

            return null;
        }

        public void Dispose()
        {
            context_?.Dispose();
        }
    }
}

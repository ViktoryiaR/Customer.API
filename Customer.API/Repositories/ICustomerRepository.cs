using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.API.Dtos;

namespace Customer.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetCustomersAsync();

        Task<CustomerDto> GetCustomerAsync(int customerId);

        Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto);
    }
}
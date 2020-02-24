using System.Linq;
using System.Threading.Tasks;
using Customer.API.Dtos;
using Customer.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository_;
        private readonly ICountryRepository countryRepository_;

        public CustomersController(
            ICustomerRepository customerRepository,
            ICountryRepository countryRepository)
        {
            customerRepository_ = customerRepository;
            countryRepository_ = countryRepository;
        }

        [HttpGet("api/customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customerDtos = await customerRepository_.GetCustomersAsync();
            var countryNameDictionary = (await countryRepository_.GetCountriesAsync()).ToDictionary(c => c.CountryId, c => c.CountryName);
            return Ok(customerDtos.Select(c => Map(c, countryNameDictionary[c.CountryId])));
        }

        [HttpPost("api/customers")]
        public async Task<IActionResult> AddCustomer([FromBody] Models.Customer customer)
        {
            var customerDto = await customerRepository_.AddCustomerAsync(Map(customer));
            var countryDto = await countryRepository_.GetCountryAsync(customerDto.CountryId);
            return Ok(Map(customerDto, countryDto.CountryName));
        }

        private Models.Customer Map(CustomerDto customerDto, string countryName)
        {
            return new Models.Customer()
            {
                CustomerId = customerDto.CustomerId,
                CustomerName = customerDto.CustomerName,
                CountryId = customerDto.CountryId,
                CountryName = countryName
            };
        }

        private CustomerDto Map( Models.Customer customer)
        {
            return new CustomerDto()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CountryId = customer.CountryId
            };
        }
    }
}

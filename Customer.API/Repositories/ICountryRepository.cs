using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.API.Dtos;

namespace Customer.API.Repositories
{
    public interface ICountryRepository
    {
        Task<List<CountryDto>> GetCountriesAsync();

        Task<CountryDto> GetCountryAsync(int countryId);
    }
}
using System.Linq;
using System.Threading.Tasks;
using Customer.API.Dtos;
using Customer.API.Models;
using Customer.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository_;

        public CountriesController(ICountryRepository countryRepository)
        {
            countryRepository_ = countryRepository;
        }

        [HttpGet("api/countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await countryRepository_.GetCountriesAsync();
            return Ok(countries.Select(Map));
        }

        private Country Map(CountryDto countryDto)
        {
            return new Country()
            {
                CountryId = countryDto.CountryId,
                CountryName = countryDto.CountryName
            };
        }
    }
}

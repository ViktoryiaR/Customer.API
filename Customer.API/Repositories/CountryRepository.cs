using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.API.Contexts;
using Customer.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Repositories
{
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private readonly CustomerInfoDbContext context_;

        public CountryRepository(CustomerInfoDbContext context)
        {
            context_ = context;
        }
        
        public Task<List<CountryDto>> GetCountriesAsync()
        {
            return context_.Countries.ToListAsync();
        }

        public Task<CountryDto> GetCountryAsync(int countryId)
        {
            return context_.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId);
        }

        public void Dispose()
        {
            context_?.Dispose();
        }
    }
}

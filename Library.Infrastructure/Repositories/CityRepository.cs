using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class CityRepository: ICityRepository
    {
        private readonly libraryContext _context;

        public CityRepository(libraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cities>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }

        public async Task<Cities> GetCity(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x=> x.IdCity == id);
            return city;
        }
    }
}

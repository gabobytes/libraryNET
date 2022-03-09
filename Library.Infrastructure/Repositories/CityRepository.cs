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
            var city = await _context.Cities.FirstOrDefaultAsync(x=> x.Id == id);
            return city;
        }

        public async Task InsertCity(Cities city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdateCity(Cities city)
        {
            var currentPost = await GetCity(city.Id);
            currentPost.NameCity = city.NameCity;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCity(int id)
        {
            var currentPost = await GetCity(id);
            _context.Cities.Remove(currentPost);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

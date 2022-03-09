using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<Cities> _cityRepository;

        public  CityService(IRepository<Cities> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Cities> GetCity(int id)
        {
            return await _cityRepository.GetById(id);
        }

        public async Task<IEnumerable<Cities>> GetCities()
        {
            return await _cityRepository.GetAll();
        }

        public async Task InsertCity(Cities city)
        {
            await _cityRepository.Add(city);
        }

        public async Task<bool> UpdateCity(Cities city)
        {
             await _cityRepository.Update(city);
            return true;
        }

        public async Task<bool> DeleteCity(int id)
        {
            await _cityRepository.Delete(id);
            return true;
        }

    }


}

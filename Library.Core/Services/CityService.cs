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
        private readonly ICityRepository _cityRepository;

        public  CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Cities> GetCity(int id)
        {
            return await _cityRepository.GetCity(id);
        }

        public async Task<IEnumerable<Cities>> GetCities()
        {
            return await _cityRepository.GetCities();
        }

        public async Task InsertCity(Cities city)
        {
            await _cityRepository.InsertCity(city);
        }

        public async Task<bool> UpdateCity(Cities city)
        {
            return await _cityRepository.UpdateCity(city);                 
        }

        public async Task<bool> DeleteCity(int id)
        {
            return await _cityRepository.DeleteCity(id);
        }

    }


}

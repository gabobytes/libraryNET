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
        private readonly IUnitOfWork _unitOFWork;

        public  CityService(IUnitOfWork unitOfWork)
        {
            _unitOFWork = unitOfWork;
        }

        public async Task<Cities> GetCity(int id)
        {
            return await _unitOFWork.CityRepository.GetById(id);
        }

        public  IEnumerable<Cities> GetCities()
        {
            return _unitOFWork.CityRepository.GetAll();

        }

        public async Task InsertCity(Cities city)
        {
            await _unitOFWork.CityRepository.Add(city);
            await _unitOFWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCity(Cities city)
        {
            _unitOFWork.CityRepository.Update(city);
            await _unitOFWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCity(int id)
        {
            await _unitOFWork.CityRepository.Delete(id);
            return true;
        }

    }


}

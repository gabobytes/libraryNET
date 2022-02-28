using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<Cities>> GetCities();
        Task<Cities> GetCity(int id);
        Task InsertCity(Cities city);
        Task<bool> UpdateCity(Cities city);
        Task<bool> DeleteCity(int id);
    }
}
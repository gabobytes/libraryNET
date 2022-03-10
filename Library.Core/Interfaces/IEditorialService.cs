using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IEditorialService
    {
        Task<bool> DeleteEditorial(int id);
        Task<Editorials> GetEditorial(int id);
        IEnumerable<Editorials> GetEditorials();
        Task InsertEditorial(Editorials editorial);
        Task<bool> UpdateEditorial(Editorials editorial);
    }
}
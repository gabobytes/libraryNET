using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> DeleteAuthor(int id);
        Task<Authors> GetAuthor(int id);
        IEnumerable<Authors> GetAuthors();
        Task InsertAuthor(Authors author);
        Task<bool> UpdateAuthor(Authors author);
    }
}
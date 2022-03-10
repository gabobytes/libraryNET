using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookService
    {
        Task<bool> DeleteBook(int id);
        Task<Books> GetBook(int id);
        IEnumerable<Books> GetBooks();
        Task InsertBook(Books book);
        Task<bool> UpdateBook(Books book);
    }
}
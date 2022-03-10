using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookRepository: IRepository<Books>
    {
        //Task<IEnumerable<Books>> GetBooks();
    }
}

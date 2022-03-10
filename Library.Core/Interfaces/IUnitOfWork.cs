using Library.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository { get;  }
        IRepository<Cities> CityRepository { get;  }
        /* en este espacio matricular todos los repos con los que trabaja la APP*/
        IBookRepository BookRepository { get; }
        IEditorialRepository EditorialRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

using Library.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Authors> AuthorRepository { get;  }
        IRepository<Cities> CityRepository { get;  }
        /* en este espacio matricular todos los repos con los que trabaja la APP*/
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly libraryContext _context; //databseconnection
        private readonly IRepository<Authors> _authorRepository;
        private readonly IRepository<Cities> _cityRepository;

        public UnitOfWork(libraryContext context)
        {
            _context = context;
        }

        public IRepository<Authors> AuthorRepository => _authorRepository ?? new BaseRepository<Authors>(_context);
        public IRepository<Cities> CityRepository => _cityRepository ?? new BaseRepository<Cities>(_context);

        public void Dispose()
        {
           if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

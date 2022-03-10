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
        private readonly IAuthorRepository _authorRepository;
        private readonly IRepository<Cities> _cityRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IEditorialRepository _editorialRepository;

        public UnitOfWork(libraryContext context)
        {
            _context = context;
        }

        public IAuthorRepository AuthorRepository => _authorRepository ?? new AuthorRepository(_context);
        public IRepository<Cities> CityRepository => _cityRepository ?? new BaseRepository<Cities>(_context);
        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_context);
        public IEditorialRepository EditorialRepository => _editorialRepository ?? new EditorialRepository(_context);

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

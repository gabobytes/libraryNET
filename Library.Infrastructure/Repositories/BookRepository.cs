using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly libraryContext _context;

        public BookRepository(libraryContext context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<Books>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}

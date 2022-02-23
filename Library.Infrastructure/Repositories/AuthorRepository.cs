using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly libraryContext _context;

        public AuthorRepository(libraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Authors>>GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }
    }
}

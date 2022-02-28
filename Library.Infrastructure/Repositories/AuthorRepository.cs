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

        public async Task<Authors> GetAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.IdAuthor == id);
            return author;
        }

        public async Task InsertAuthor(Authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAuthor(Authors author)
        {
            var currentAuthor = await GetAuthor(author.IdAuthor);
            currentAuthor.Fullname = author.Fullname;
            currentAuthor.Datebirth = author.Datebirth;
            currentAuthor.IdCityBirth = author.IdCityBirth;
            currentAuthor.Email = author.Email;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var currentAuthor = await GetAuthor(id);
            _context.Authors.Remove(currentAuthor);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }


    }
}

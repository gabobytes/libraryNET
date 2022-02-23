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
    public class GenreRepository: IGenreRepository
    {
        private readonly libraryContext _context;

        public GenreRepository(libraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genres>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres;
        }
    }
}

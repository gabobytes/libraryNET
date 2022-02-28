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

        public async Task<Books> GetBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.IdBook == id);
            return book;
        }

        public async Task InsertBook(Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var currentBook = await GetBook(book.id_book);
            currentBook.Title = book.title;
            currentBook.Year = book.year;
            currentBook.IdGenre = book.id_genre;
            currentBook.Numberpages = book.numberpages;
            currentBook.IdEditorial = book.id_editorial;
            currentBook.IdAuthor = book.id_author;

            int rows = await _context.SaveChangesAsync();
            return rows >0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var currentBook = await GetBook(id);
            _context.Books.Remove(currentBook);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

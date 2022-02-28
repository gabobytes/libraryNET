using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            return await _authorRepository.GetAuthors();
        }

        public async Task<Authors> GetAuthor(int id)
        {
            return await _authorRepository.GetAuthor(id);
        }

        public async Task InsertAuthor(Authors author)
        {
            await _authorRepository.InsertAuthor(author);
        }

        public async Task<bool> UpdateAuthor(Authors author)
        {
            return await _authorRepository.UpdateAuthor(author);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthor(id);
        }
    }
}

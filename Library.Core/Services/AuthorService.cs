﻿using Library.Core.Entities;
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
        private readonly ICityRepository _cityRepository;

        public AuthorService(IAuthorRepository authorRepository, ICityRepository cityRepository)
        {
            _authorRepository = authorRepository;
            _cityRepository = cityRepository;
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

            var city = await _cityRepository.GetCity(author.IdCityBirth);
            if (city == null)
            {
                throw new Exception("City doesn't exists");
            }

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

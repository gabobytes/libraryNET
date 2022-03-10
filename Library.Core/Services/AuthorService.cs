using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOFWork;
        

        public AuthorService(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        
        }

        public IEnumerable<Authors> GetAuthors()
        {
            return _unitOFWork.AuthorRepository.GetAll();
        }

        public async Task<Authors> GetAuthor(int id)
        {
            return await _unitOFWork.AuthorRepository.GetById(id);
        }

        public async Task InsertAuthor(Authors author)
        {

            var city = await _unitOFWork.CityRepository.GetById(author.IdCityBirth);
            if (city == null)
            {
                throw new BusinessException("City doesn't exists");
            }
            
            await _unitOFWork.AuthorRepository.Add(author);
            await _unitOFWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAuthor(Authors author)
        {
            _unitOFWork.AuthorRepository.Update(author);
            await _unitOFWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            await _unitOFWork.AuthorRepository.Delete(id);
            return true;
        }
    }
}

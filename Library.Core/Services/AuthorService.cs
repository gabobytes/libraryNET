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
        private readonly IUnitOfWork _unitOFWork;
        

        public AuthorService(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        
        }

        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            return await _unitOFWork.AuthorRepository.GetAll();
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
                throw new Exception("City doesn't exists");
            }
            
            await _unitOFWork.AuthorRepository.Add(author);
        }

        public async Task<bool> UpdateAuthor(Authors author)
        {
            await _unitOFWork.AuthorRepository.Update(author);
            return true;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            await _unitOFWork.AuthorRepository.Delete(id);
            return true;
        }
    }
}

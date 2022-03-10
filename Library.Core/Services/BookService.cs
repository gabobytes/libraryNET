using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookService :  IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public IEnumerable<Books> GetBooks()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        public async Task<Books> GetBook(int id)
        {
            return await _unitOfWork.BookRepository.GetById(id);
        }

        public async Task InsertBook(Books book)
        {

            //var city = await _unitOfWork.CityRepository.GetById(author.IdCityBirth);
            /*if (city == null)
            {
                throw new BusinessException("City doesn't exists");
            }*/

            var author = await _unitOfWork.AuthorRepository.GetById(book.IdAuthor);
            

            if(author == null)
            {
                throw new BusinessException("El autor no está registrado");
            }

            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateBook(Books book)
        {
            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBook(int id)
        {
            await _unitOfWork.BookRepository.Delete(id);
            return true;
        }


    }
}

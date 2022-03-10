using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class EditorialService :  IEditorialService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditorialService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IEnumerable<Editorials> GetEditorials()
        {
            return _unitOfWork.EditorialRepository.GetAll();
        }

        public async Task<Editorials> GetEditorial(int id)
        {
            return await _unitOfWork.EditorialRepository.GetById(id);
        }

        public async Task InsertEditorial(Editorials editorial)
        {
            await _unitOfWork.EditorialRepository.Add(editorial);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEditorial(Editorials editorial)
        {
            _unitOfWork.EditorialRepository.Update(editorial);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEditorial(int id)
        {
            await _unitOfWork.EditorialRepository.Delete(id);
            return true;
        }






    }
}

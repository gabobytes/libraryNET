using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //here we define the CRUD
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);        

    }
}

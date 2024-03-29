﻿using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly libraryContext _context; //databseconnection
        protected DbSet<T> _entities; //se registraran aqui los tipos T que se recibn.

        public BaseRepository(libraryContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }


        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
           /* _entities.Add(entity);
            await _context.SaveChangesAsync();*/


            //Dont work:
            await _entities.AddAsync(entity);

        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            
        }


    }
}

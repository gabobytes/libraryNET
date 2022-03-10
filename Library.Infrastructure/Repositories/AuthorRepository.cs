using Library.Core.Entities;
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
    public class AuthorRepository : BaseRepository<Authors>, IAuthorRepository
    {
        //esto se envía porque el BaseRepository en su constructor recibe este mismo parámetro
        public AuthorRepository(libraryContext context) : base(context) {  } 
     

        public async Task<IEnumerable<Authors>> GetAuthorsByCity(int idCity)
        {
            return await _entities.Where(x => x.IdCityBirth == idCity).ToListAsync(); //siendo pocos list se utiliza asi, sino se utilizaria TOList

        }
    }
}

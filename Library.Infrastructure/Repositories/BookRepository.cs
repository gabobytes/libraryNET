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
    public class BookRepository : BaseRepository<Books>, IBookRepository
    {

        private readonly libraryContext _context;

        //esto se envía porque el BaseRepository en su constructor recibe este mismo parámetro
        public BookRepository(libraryContext context) : base(context) { }


        
    }
}

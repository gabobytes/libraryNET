using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int IdGenre { get; set; }
        public int Numberpages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }
    }
}

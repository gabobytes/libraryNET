using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.DTOs
{
    public class AuthorDto
    {
        public int IdAuthor { get; set; }
        public string Fullname { get; set; }
        public DateTime Datebirth { get; set; }
        public int IdCityBirth { get; set; }
        public string Email { get; set; }
    }
}

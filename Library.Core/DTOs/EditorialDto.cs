using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.DTOs
{
    public class EditorialDto
    {
        public int Id { get; set; }
        public string NameEditorial { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? MaxBooksRegistered { get; set; }
    }
}

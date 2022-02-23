using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Core.Entities
{
    public partial class Editorials
    {
        public Editorials()
        {
            Books = new HashSet<Books>();
        }

        public int IdEditorial { get; set; }
        public string NameEditorial { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? MaxBooksRegistered { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}

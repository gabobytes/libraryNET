using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Core.Entities
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }

        public int IdGenre { get; set; }
        public string NameGenre { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}

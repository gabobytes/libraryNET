using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Core.Entities
{
    public partial class Books: BaseEntity
    {
        
        public string Title { get; set; }
        public int Year { get; set; }
        public int IdGenre { get; set; }
        public int Numberpages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }

        public virtual Authors IdAuthorNavigation { get; set; }
        public virtual Editorials IdEditorialNavigation { get; set; }
        public virtual Genres IdGenreNavigation { get; set; }
    }
}

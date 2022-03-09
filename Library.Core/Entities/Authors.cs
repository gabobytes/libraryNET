using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Core.Entities
{
    public partial class Authors: BaseEntity
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        
        public string Fullname { get; set; }
        public DateTime Datebirth { get; set; }
        public int IdCityBirth { get; set; }
        public string Email { get; set; }

        public virtual Cities IdCityBirthNavigation { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}

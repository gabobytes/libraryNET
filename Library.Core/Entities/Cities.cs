﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Core.Entities
{
    public partial class Cities : BaseEntity
    {
        public Cities()
        {
            Authors = new HashSet<Authors>();
        }

        
        
        public string NameCity { get; set; }

        public virtual ICollection<Authors> Authors { get; set; }
    }
}

using System;
using Library.Core.Entities;
using Library.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Infrastructure.Data
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Editorials> Editorials { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new BookConfiguration());

            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.ApplyConfiguration(new EditorialConfiguration());

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
         
        }

        
    }
}

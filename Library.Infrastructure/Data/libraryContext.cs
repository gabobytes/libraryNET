using System;
using Library.Core.Entities;
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
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.ToTable("authors");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.Datebirth)
                    .HasColumnName("datebirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdCityBirth).HasColumnName("id_city_birth");

                entity.HasOne(d => d.IdCityBirthNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdCityBirth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_authors_citybirth");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("books");

                entity.Property(e => e.IdBook).HasColumnName("id_book");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.Numberpages).HasColumnName("numberpages");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_books_authors");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_books_editorials");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_books_genres");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.ToTable("cities");

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.NameCity)
                    .IsRequired()
                    .HasColumnName("name_city")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Editorials>(entity =>
            {
                entity.HasKey(e => e.IdEditorial);

                entity.ToTable("editorials");

                entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MaxBooksRegistered).HasColumnName("max_books_registered");

                entity.Property(e => e.NameEditorial)
                    .IsRequired()
                    .HasColumnName("name_editorial")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.IdGenre);

                entity.ToTable("genres");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.NameGenre)
                    .IsRequired()
                    .HasColumnName("name_genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

         
        }

        
    }
}

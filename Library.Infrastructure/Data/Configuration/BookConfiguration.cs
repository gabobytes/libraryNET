using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    public class BookConfiguration :  IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("books");

            builder.Property(e => e.Id).HasColumnName("id_book");

            builder.Property(e => e.IdAuthor).HasColumnName("id_author");

            builder.Property(e => e.IdEditorial).HasColumnName("id_editorial");

            builder.Property(e => e.IdGenre).HasColumnName("id_genre");

            builder.Property(e => e.Numberpages).HasColumnName("numberpages");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Year).HasColumnName("year");

            builder.HasOne(d => d.IdAuthorNavigation)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_books_authors");

            builder.HasOne(d => d.IdEditorialNavigation)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.IdEditorial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_books_editorials");

            builder.HasOne(d => d.IdGenreNavigation)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_books_genres");
        }
    }
}

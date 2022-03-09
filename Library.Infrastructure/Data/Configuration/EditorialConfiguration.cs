using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorials>
    {
        public void Configure(EntityTypeBuilder<Editorials> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("editorials");

            builder.Property(e => e.Id).HasColumnName("id_editorial");

            builder.Property(e => e.Address)
                .IsRequired()
                .HasColumnName("address")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.MaxBooksRegistered).HasColumnName("max_books_registered");

            builder.Property(e => e.NameEditorial)
                .IsRequired()
                .HasColumnName("name_editorial")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasColumnName("phone")
                .HasMaxLength(15)
                .IsUnicode(false);
        }
    }
}

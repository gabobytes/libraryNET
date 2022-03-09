using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    public class AuthorConfiguration: IEntityTypeConfiguration<Authors>
    {
        public void Configure(EntityTypeBuilder<Authors> builder)
            {
            builder.HasKey(e => e.Id);

            builder.ToTable("authors");

            builder.Property(e => e.Id).HasColumnName("id_author");

            builder.Property(e => e.Datebirth)
                .HasColumnName("datebirth")
                .HasColumnType("date");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Fullname)
                .IsRequired()
                .HasColumnName("fullname")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.IdCityBirth).HasColumnName("id_city_birth");

            builder.HasOne(d => d.IdCityBirthNavigation)
                .WithMany(p => p.Authors)
                .HasForeignKey(d => d.IdCityBirth)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_authors_citybirth");
        }
    }
}


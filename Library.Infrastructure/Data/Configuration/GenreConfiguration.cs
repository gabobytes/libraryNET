using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genres>
    {
        public void Configure(EntityTypeBuilder<Genres> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("genres");

            builder.Property(e => e.Id ).HasColumnName("id_genre");

            builder.Property(e => e.NameGenre)
                .IsRequired()
                .HasColumnName("name_genre")
                .HasMaxLength(50)
                .IsUnicode(false);
        }

    }
}

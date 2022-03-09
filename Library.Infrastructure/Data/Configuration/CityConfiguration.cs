using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<Cities>
    {
        public void Configure(EntityTypeBuilder<Cities> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("cities");

            builder.Property(e => e.Id).HasColumnName("id_city");

            builder.Property(e => e.NameCity)
                .IsRequired()
                .HasColumnName("name_city")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}

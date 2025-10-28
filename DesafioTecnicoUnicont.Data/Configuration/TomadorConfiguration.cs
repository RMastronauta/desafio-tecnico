using DesafioTecnicoUnicont.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Data.Configuration
{
    public class TomadorConfiguration : IEntityTypeConfiguration<Tomador>
    {
        public void Configure(EntityTypeBuilder<Tomador> builder)
        {
            builder.ToTable("TOMADOR");

            builder.HasKey(x => x.Id)
                   .HasName("PK_TOMADOR");

            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(x => x.Cnpj)
                   .HasColumnName("CNPJ")
                   .HasMaxLength(14)
                   .IsRequired();
        }
    }
}

using DesafioTecnicoUnicont.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoUnicont.Data.Configuration
{
    public class PrestadorConfiguration: IEntityTypeConfiguration<Prestador>
    {
        public void Configure(EntityTypeBuilder<Prestador> builder)
        {
            builder.ToTable("PRESTADOR");

            builder.HasKey(x => x.Id)
                   .HasName("PK_PRESTADOR");

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

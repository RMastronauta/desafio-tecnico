using DesafioTecnicoUnicont.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoUnicont.Data.Configuration
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("SERVICO");

            builder.HasKey(x => x.Id)
                   .HasName("PK_SERVICO");

            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasColumnName("DESCRICAO")
                   .HasColumnType("NVARCHAR(MAX)");

            builder.Property(x => x.Valor)
                   .HasColumnName("VALOR")
                   .HasColumnType("DECIMAL")
                   .IsRequired();
        }
    }
}

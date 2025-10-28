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
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.ToTable("NOTAFISCAL");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.NumeroNota)
                .HasColumnName("NUMNOTA")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DataEmissao)
                .HasColumnName("DATAEMISSAO")
                .IsRequired();


            // Relacionamentos (FKs)
            builder.HasOne(n => n.Prestador)
                .WithMany(p => p.NotasFiscais)
                .HasForeignKey("IdPrestador")
                .HasConstraintName("FK_NOTA_PRESTADOR");

            builder.HasOne(n => n.Tomador)
                .WithMany(t => t.NotasFiscais)
                .HasForeignKey("IdTomador")
                .HasConstraintName("FK_NOTA_TOMADOR");

            builder.HasOne(n => n.Servico)
                .WithOne(s => s.NotaFiscal)
                .HasForeignKey<NotaFiscal>("IdServico")
                .HasConstraintName("FK_NOTA_SERVICO");
        }
    }
}

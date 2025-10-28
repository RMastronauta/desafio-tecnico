using DesafioTecnicoUnicont.Domain.Dto;
using DesafioTecnicoUnicont.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Mapper
{
    public static class NotaFiscalMapper
    {
        public static NotaFiscal ToEntity(this NotaFiscalXmlDto nota)
        {
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota), "O DTO da Nota Fiscal não pode ser nulo.");
            }

            var entity = new NotaFiscal
            {
                NumeroNota = nota.Numero,
                DataEmissao = nota.DataEmissao,
                Prestador = nota.Prestador != null
                    ? new Prestador(nota.Prestador.CNPJ)
                    : new Prestador(),

                Tomador = nota.Tomador != null
                    ? new Tomador(nota.Tomador.CNPJ)
                    : new Tomador(),

                Servico = nota.Servico != null
                    ? new Servico(nota.Servico.Descricao, nota.Servico.Valor)
                    : new Servico()
            };

            return entity;
        }

        public static NotaFiscalCreatedResponseDto ToDto(this NotaFiscal nota)
        {
            var dto =  new NotaFiscalCreatedResponseDto
            {
                Id = nota.Id,
                NumeroNota = nota.NumeroNota,
                DataEmissao = nota.DataEmissao,
                Prestador = new PrestadorCreatedResponseDto(nota.Prestador.Id, nota.Prestador.Cnpj),
                Tomador = new TomadorCreatedResponseDto(nota.Tomador.Id, nota.Tomador.Cnpj),
                Servico = new ServicoCreatedResponseDto(nota.Servico.Id, nota.Servico.Descricao, nota.Servico.Valor)
            };
            return dto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Dto
{
    public class NotaFiscalCreatedResponseDto
    {
        public NotaFiscalCreatedResponseDto()
        {
        }
        public NotaFiscalCreatedResponseDto(int id, string? numNota, DateTime dataEmissao, PrestadorCreatedResponseDto prestador, TomadorCreatedResponseDto tomador, ServicoCreatedResponseDto servico)
        {
            Id = id;
            NumeroNota = numNota;
            DataEmissao = dataEmissao;
            Prestador = prestador;
            Tomador = tomador;
            Servico = servico;
        }

        public int Id { get; set; }
        public string? NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public PrestadorCreatedResponseDto Prestador { get; set; }
        public TomadorCreatedResponseDto Tomador { get; set; }
        public ServicoCreatedResponseDto Servico { get; set; }
    }
}

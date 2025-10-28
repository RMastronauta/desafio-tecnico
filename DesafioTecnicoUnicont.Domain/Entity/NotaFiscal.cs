using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Entity
{
    public class NotaFiscal : EntityBase
    {
        public NotaFiscal() 
        {
        }

        public NotaFiscal(string numeroNota, DateTime dataEmissao) 
        {
            NumeroNota = numeroNota;
            DataEmissao = dataEmissao;
            Servico = new Servico();
            Prestador = new Prestador();
            Tomador = new Tomador();
        }
        public string NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }

        public Servico Servico { get; set; }
        public Prestador Prestador { get; set; }
        public Tomador Tomador { get; set; }
    }
}

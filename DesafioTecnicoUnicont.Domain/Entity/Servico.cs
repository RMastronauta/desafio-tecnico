using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Entity
{
    public class Servico : EntityBase
    {
        public Servico() {
        }
        public Servico(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
            NotaFiscal = new NotaFiscal();
        }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
    }
}

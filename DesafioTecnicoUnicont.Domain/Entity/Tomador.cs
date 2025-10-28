using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Entity
{
    public class Tomador: PessoaBase
    {
        public Tomador() 
        {
        }
        public Tomador(int id, string cnpj) 
            : base(id, cnpj)
        {
            NotasFiscais = new List<NotaFiscal>();
        }    
        public Tomador(string cnpj) 
            : base(cnpj)
        {
            NotasFiscais = new List<NotaFiscal>();
        }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}

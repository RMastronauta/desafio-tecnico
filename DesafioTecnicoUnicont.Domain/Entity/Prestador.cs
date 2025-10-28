using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Entity
{
    public class Prestador: PessoaBase
    {
        public Prestador() 
        {
        }
        public Prestador(string cnpj) : base(cnpj)
        {
            NotasFiscais = new List<NotaFiscal>();
        }
        public Prestador(int id, string cnpj) 
            :base(id, cnpj)
        {
            NotasFiscais = new List<NotaFiscal>();
        }

        public ICollection<NotaFiscal> NotasFiscais;
    }
}

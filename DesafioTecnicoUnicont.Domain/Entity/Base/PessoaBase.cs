using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Entity.Base
{
    public class PessoaBase : EntityBase
    {
        public PessoaBase() { }
        public  PessoaBase(string cnpj) 
        {
            Cnpj = cnpj;
        }
        public PessoaBase(int Id, string cnpj) 
        {
            this.Id = Id;
            Cnpj = cnpj;
        }
        public string Cnpj { get; set; }
    }
}

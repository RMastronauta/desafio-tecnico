using DesafioTecnicoUnicont.Data.Context;
using DesafioTecnicoUnicont.Data.Repository.Base;
using DesafioTecnicoUnicont.Domain.Entity;
using DesafioTecnicoUnicont.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Data.Repository
{
    public class NotaFiscalRepository : RepositoryBase<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(DesafioTecnicoUnicontContext context) : base(context)
        {
        }
    }
}

using DesafioTecnicoUnicont.Domain.Dto;
using DesafioTecnicoUnicont.Domain.Entity;
using DesafioTecnicoUnicont.Domain.Interface.Service.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Interface.Service
{
    public interface INotaFiscalService : IServiceBase<NotaFiscal>
    {
        Task<NotaFiscal> InserirNotasFiscaisByXml(IFormFile arquivo);
        Task ProcessarArquivos(IEnumerable<IFormFile> arquivo);
        Task<NotaFiscalCreatedResponseDto> InserirNotaFiscalByArquivoBase(ArquivoBase file);
    }
}

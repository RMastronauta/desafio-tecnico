using DesafioTecnicoUnicont.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicode.Worker.Interface
{
    public interface INotaFiscalWorkerService
    {
        Task<string> EnviarArquivo(ArquivoBase meuArquivo);
    }
}

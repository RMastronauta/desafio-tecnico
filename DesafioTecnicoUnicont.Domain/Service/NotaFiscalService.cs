using DesafioTecnicoUnicont.Domain.Dto;
using DesafioTecnicoUnicont.Domain.Entity;
using DesafioTecnicoUnicont.Domain.Extention;
using DesafioTecnicoUnicont.Domain.Interface.Repository;
using DesafioTecnicoUnicont.Domain.Interface.Repository.Base;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using DesafioTecnicoUnicont.Domain.Mapper;
using DesafioTecnicoUnicont.Domain.Service.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Service
{
    public class NotaFiscalService : ServiceBase<NotaFiscal>, INotaFiscalService
    {
        protected INotaFiscalRepository _repository { get { return base._repository as INotaFiscalRepository ?? throw new ArgumentException("Ocorreu um erro ao realizar a injeção de depedência."); } }
        protected readonly IRabbitMqService _rabbitMqService;

        public NotaFiscalService(INotaFiscalRepository repository, IRabbitMqService rabbitMqService)
            : base(repository)
        {
            _rabbitMqService = rabbitMqService;
        }
        public async Task<NotaFiscal> InserirNotasFiscaisByXml(IFormFile arquivo)
        {
            var nota = await arquivo.ToEntityByXml<NotaFiscalXmlDto>();
            var entity = nota.ToEntity();
            return await _repository.AddAsync(entity);
        }
        public async Task ProcessarArquivos(IEnumerable<IFormFile> arquivo)
        {
            foreach (var file in arquivo)
            {
                var nota = await file.ToFileBaseByArquivo();
                await _rabbitMqService.SendMessageAsync(nota);
            }
        }
        public async Task<NotaFiscalCreatedResponseDto> InserirNotaFiscalByArquivoBase(ArquivoBase file)
        {
            var formFile = await file.ToFormFileByArquivo();
            var nota =  await InserirNotasFiscaisByXml(formFile);
            return nota.ToDto();
        }
    }
}

using DesafioTecnicoUnicont.Domain.Dto;
using DesafioTecnicoUnicont.Domain.Entity;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using DesafioTecnicoUnicont.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoUnicont.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private ILogger<NotaFiscalController> _logger;
        protected readonly INotaFiscalService _service;
        public NotaFiscalController(INotaFiscalService service, ILogger<NotaFiscalController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("inserirnotafiscalbyxml")]
        public async Task<IActionResult> InserirNotaFiscal([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0 || !file.ContentType.Contains("xml"))
                    return BadRequest("Arquivo XML é obrigatório.");

                var nota = await _service.InserirNotasFiscaisByXml(file);

                return Ok(new
                {
                    success = true,
                    Message = "Nota fiscal inserida com sucesso.",
                    data = nota.ToDto()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir notal fiscal por XML.");
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Erro ao processar o XML: {ex.Message}"
                });
            }
        }

        [HttpPost]
        [Route("inserirnotasfiscaisbyxml")]
        public async Task<IActionResult> InserirNotasFiscaisByXml([FromForm] IEnumerable<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count() == 0)
                    throw new FileNotFoundException("É necessário informar pelo menos um arquivo.");
                await _service.ProcessarArquivos(files);
                return Accepted(new
                {
                    success = true,
                    mensagem = "Notas fiscais estão sendo processadas em segundo plano."
                });

            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir notas fiscais por XML.");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocorreu um erro ao processar os arquivos XML."
                });
            }

        }
    }
}

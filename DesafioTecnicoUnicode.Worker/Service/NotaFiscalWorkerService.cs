using DesafioTecnicoUnicode.Worker.Dto;
using DesafioTecnicoUnicode.Worker.Interface;
using DesafioTecnicoUnicont.Domain.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicode.Worker.Service
{
    public class NotaFiscalWorkerService : INotaFiscalWorkerService
    {
        private readonly string _baseUrl;
        private readonly string _endpoint;

        private readonly IConfiguration _configuration;


        public NotaFiscalWorkerService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["NotaFiscalApi:BaseUrl"] ?? string.Empty;
            _endpoint = _configuration["NotaFiscalApi:InserirEndpoint"] ?? string.Empty;
        }

        public async Task<string> EnviarArquivo(ArquivoBase meuArquivo)
        {
            if (meuArquivo == null || string.IsNullOrEmpty(meuArquivo.Content))
                throw new ArgumentException("O arquivo é inválido ou está vazio.", nameof(meuArquivo));

            var fileBytes = Convert.FromBase64String(meuArquivo.Content);

            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(meuArquivo.ContentType);

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileContent, "file", meuArquivo.FileName);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    var response = await client.PostAsync(_endpoint, formData);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonSerializer.Deserialize<ResponseBaseApi>(jsonString,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        if (apiResponse != null)
                        {
                            if (apiResponse.Success)
                            {
                                return apiResponse.Message;
                            }
                            throw new Exception($"Erro da API: {apiResponse.Message}");
                        }
                        throw new Exception("Erro ao desserializar a resposta da API.");
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Erro HTTP: {response.StatusCode} - {response.ReasonPhrase}. {Environment.NewLine} Resposta: {errorContent}");
                    }
                }
            }
        }
    }

}

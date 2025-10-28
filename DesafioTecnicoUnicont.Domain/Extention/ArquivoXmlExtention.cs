using DesafioTecnicoUnicont.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesafioTecnicoUnicont.Domain.Extention
{
    public static class ArquivoXmlExtention
    {
        public static async Task<TEntity> ToEntityByXml<TEntity>(this IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("O arquivo XML é inválido ou está vazio.", nameof(file));

            try
            {
                await using (var stream = file.OpenReadStream())
                {
                    var serializer = new XmlSerializer(typeof(TEntity));

                    if (serializer.Deserialize(stream) is not TEntity dados)
                        throw new InvalidOperationException($"Não foi possível desserializar o XML em {typeof(TEntity).Name}.");

                    return dados;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ArquivoBase> ToFileBaseByArquivo(this IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("O arquivo XML é inválido ou está vazio.", nameof(file));

            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            return new ArquivoBase
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Content = Convert.ToBase64String(fileBytes)
            };
        }
        public static async Task<IFormFile> ToFormFileByArquivo(this ArquivoBase file)
        {
            //Convert arquivo do tipo arquivoBase em IFormFile
            if (file == null || string.IsNullOrEmpty(file.Content))
                throw new ArgumentException("O arquivo é inválido ou está vazio.", nameof(file));
            var fileBytes = Convert.FromBase64String(file.Content);
            var stream = new MemoryStream(fileBytes);
            return await Task.FromResult(new FormFile(stream, 0, fileBytes.Length, "file", file.FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = file.ContentType
            });
        }
    }
}

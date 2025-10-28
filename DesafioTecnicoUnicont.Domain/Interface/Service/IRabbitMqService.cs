using DesafioTecnicoUnicont.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Interface.Service
{
    public interface IRabbitMqService
    {
        Task SendMessageAsync<TEntity>(TEntity entity);
        Task<ArquivoBase> GetMessageAsync(string hostName, string queueName);
    }
}

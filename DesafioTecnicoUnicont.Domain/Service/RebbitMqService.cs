using DesafioTecnicoUnicont.Domain.Entity;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

public class RabbitMqService : IRabbitMqService
{   
    public async Task SendMessageAsync<TEntity>(TEntity entity)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        var messageJson = JsonSerializer.Serialize(entity);
        var body = Encoding.UTF8.GetBytes(messageJson);

        var basicProperties = new BasicProperties
        {
            ContentType = "application/json"
        };

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: "notaFiscalQueue",
            mandatory: false,
            basicProperties: basicProperties,
            body: body
        );
    }
    public async Task<ArquivoBase?> GetMessageAsync(string hostName, string queueName)
    {
        var factory = new ConnectionFactory
        {
            HostName = hostName
        };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        var getResult = await channel.BasicGetAsync(queueName, autoAck: false);

        if (getResult == null)
        {
            return null;
        }

        ArquivoBase? result = null;
        try
        {
            var body = getResult.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            result = JsonSerializer.Deserialize<ArquivoBase>(message);
            await channel.BasicAckAsync(getResult.DeliveryTag, false);
        }
        catch (Exception ex)
        {
            await channel.BasicNackAsync(getResult.DeliveryTag, false, true);
        }
        return result;
    }
}

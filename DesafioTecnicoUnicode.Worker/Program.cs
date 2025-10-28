using DesafioTecnicoUnicode.Worker.Interface;
using DesafioTecnicoUnicode.Worker.Service;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IRabbitMqService, RabbitMqService>();
                services.AddSingleton<INotaFiscalWorkerService, NotaFiscalWorkerService>();
                services.AddHostedService<NotaFiscalProcessor>();
            })
            .Build();
        await host.RunAsync();
    }
}
using DesafioTecnicoUnicode.Worker.Interface;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using Microsoft.Extensions.Hosting;

public class NotaFiscalProcessor : BackgroundService
{
    private readonly IRabbitMqService _rabbitMqService;
    private readonly INotaFiscalWorkerService _notaFiscalService; // Removi o namespace completo para clareza

    public NotaFiscalProcessor(IRabbitMqService rabbitMqService,
                               INotaFiscalWorkerService notaFiscalService)
    {
        _rabbitMqService = rabbitMqService;
        _notaFiscalService = notaFiscalService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var arquivo = await _rabbitMqService.GetMessageAsync("localhost", "notaFiscalQueue");

                if (arquivo != null)
                {
                    Console.WriteLine("Processando Nota Fiscal...");
                    var response = await _notaFiscalService.EnviarArquivo(arquivo);
                    Console.WriteLine($"Resposta da API: {response}");
                }
                else
                {
                    Console.WriteLine("Nenhuma mensagem na fila. Aguardando 5s...");
                    await Task.Delay(5000, stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Serviço de processamento de nota fiscal está parando.");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
                Console.WriteLine("Aguardando 10s antes de tentar novamente...");
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
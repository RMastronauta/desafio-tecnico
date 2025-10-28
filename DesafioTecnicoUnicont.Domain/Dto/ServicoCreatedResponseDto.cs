namespace DesafioTecnicoUnicont.Domain.Dto
{
    public class ServicoCreatedResponseDto
    {
        public ServicoCreatedResponseDto(int id, string descricao, decimal valor)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
        }
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }

    }
}
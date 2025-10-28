namespace DesafioTecnicoUnicont.Domain.Dto
{
    public class PrestadorCreatedResponseDto
    {
        public PrestadorCreatedResponseDto(int id, string? cnpj)
        {
            Id = id;
            Cnpj = cnpj;
        }

        public int Id { get; set; }
        public string? Cnpj { get; set; }
    }
}
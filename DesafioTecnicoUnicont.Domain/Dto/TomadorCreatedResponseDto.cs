namespace DesafioTecnicoUnicont.Domain.Dto
{
    public class TomadorCreatedResponseDto
    {
        public TomadorCreatedResponseDto(int id, string? cnpj)
        {
            Id = id;
            Cnpj = cnpj;
        }

        public int Id { get; set; }
        public string? Cnpj { get; set; }
    }
}

namespace gestaoRh.Api.DTOs;

public class EmpresaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public EnderecoDto? Endereco { get; set; }
}

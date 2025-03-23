using gestaoRh.Api.DTOs;

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public Endereco? Endereco { get; set; }

    public static implicit operator Empresa?(EmpresaDto? v)
    {
        throw new NotImplementedException();
    }
}
public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Nacionalidade { get; set; }
    public string EstadoCivil { get; set; }
    public string Sexo { get; set; }
    public string Telefone { get; set; }
    public EnderecoDto? Endereco { get; set; }
    public List<DocumentosDto>? Documentos { get; set; }
}

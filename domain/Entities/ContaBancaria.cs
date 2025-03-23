public class ContaBancaria
{
    public int Id { get; set; }
    public string NumeroBanco { get; set; }
    public string Banco { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public Usuario Usuario { get; set; }
}
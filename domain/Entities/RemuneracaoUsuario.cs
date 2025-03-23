public class RemuneracaoUsuario
{
    public int Id { get; set; }
    public decimal SalarioFixo { get; set; }
    public decimal Complemento { get; set; }
    public decimal SalarioAdicional { get; set; }
    public decimal PercentualInsalubridade { get; set; }
    public decimal PercentualPericulosidade { get; set; }
    public string TipoSalario { get; set; }
}
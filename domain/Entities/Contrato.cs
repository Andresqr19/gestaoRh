public class Contrato
{
    public int Id { get; set; }
    public Usuario Usuario { get; set; }
    public string TipoContrato { get; set; }
    public DateTime DataAdmissao { get; set; }
    public string FichaRegistro { get; set; }
    public string EstabilidadeProvisoria { get; set; }
    public string Cargo { get; set; }
    public string CBO { get; set; }
    public string Departamento { get; set; }
    public string CentroCusto { get; set; }
    public string EscalaTrabalho { get; set; }
    public string VinculoEmpregaticio { get; set; }
    public string PostoTrabalho { get; set; }
    public Empresa Empresa { get; set; }
}

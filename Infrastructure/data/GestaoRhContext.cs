using Microsoft.EntityFrameworkCore;

public class GestaoRhContext : DbContext
{
    public GestaoRhContext(DbContextOptions<GestaoRhContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<ContaBancaria> ContasBancarias { get; set; }
    public DbSet<RemuneracaoUsuario> RemuneracoesUsuarios { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseNpgsql("Host=localhost;Port=5432;Database=gestaorh;Username=gestaorh;Password=gestaorh123") // String de conexão do PostgreSQL
        .EnableSensitiveDataLogging(); // Habilita o logging sensível
    }
}

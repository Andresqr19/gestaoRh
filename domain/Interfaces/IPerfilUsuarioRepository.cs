public interface IPerfilUsuarioRepository
{
    Task<IEnumerable<PerfilUsuario>> GetAllAsync();
    Task<PerfilUsuario> GetByIdAsync(int id);
    Task<PerfilUsuario> AddAsync(PerfilUsuario perfilUsuario);
    Task UpdateAsync(PerfilUsuario perfilUsuario);
    Task DeleteAsync(PerfilUsuario perfilUsuario);
}

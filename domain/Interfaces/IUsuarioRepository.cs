public interface IUsuarioRepository
{
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<Usuario> GetByIdAsync(int id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task<bool> DeleteAsync(int id);
}

public interface IUsuarioService
{
    Task<UsuarioDto> AddAsync(UsuarioDto usuarioDto);
    Task<UsuarioDto> GetByIdAsync(int id);
    Task<IEnumerable<UsuarioDto>> GetAllAsync();
    Task UpdateAsync(int id, UsuarioDto usuarioDto);
    Task<bool> DeleteAsync(int id);
}
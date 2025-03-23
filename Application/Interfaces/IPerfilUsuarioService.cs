public interface IPerfilUsuarioService
{
    Task<IEnumerable<PerfilUsuarioDto>> GetAllAsync();
    Task<PerfilUsuarioDto> GetByIdAsync(int id);
    Task<PerfilUsuarioDto> AddAsync(PerfilUsuarioDto perfilUsuarioDto);
    Task<PerfilUsuarioDto> UpdateAsync(int id, PerfilUsuarioDto perfilUsuarioDto);
    Task<bool> DeleteAsync(int id);
}

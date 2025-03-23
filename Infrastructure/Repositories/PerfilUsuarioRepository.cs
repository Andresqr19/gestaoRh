using Microsoft.EntityFrameworkCore;

public class PerfilUsuarioRepository : IPerfilUsuarioRepository
{
    private readonly GestaoRhContext _context;

    public PerfilUsuarioRepository(GestaoRhContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PerfilUsuario>> GetAllAsync()
    {
        return await _context.PerfisUsuarios.ToListAsync();
    }

    public async Task<PerfilUsuario> GetByIdAsync(int id)
    {
        return await _context.PerfisUsuarios.FindAsync(id);
    }

    public async Task<PerfilUsuario> AddAsync(PerfilUsuario perfilUsuario)
    {
        _context.PerfisUsuarios.Add(perfilUsuario);
        await _context.SaveChangesAsync();
        return perfilUsuario;
    }

    public async Task UpdateAsync(PerfilUsuario perfilUsuario)
    {
        _context.PerfisUsuarios.Update(perfilUsuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PerfilUsuario perfilUsuario)
    {
        _context.PerfisUsuarios.Remove(perfilUsuario);
        await _context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly GestaoRhContext _context;

    public UsuarioRepository(GestaoRhContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        // Adiciona o usuário ao contexto
        await _context.Usuarios.AddAsync(usuario);
        
        // Salva as alterações no banco
        await _context.SaveChangesAsync();
        
        return usuario;
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        // Busca o usuário pelo ID, incluindo Endereco e Documentos relacionados
        return await _context.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Documentos)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        // Retorna todos os usuários, incluindo Endereco e Documentos relacionados
        return await _context.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Documentos)
            .ToListAsync();
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        // Verifica se o usuário já existe no banco de dados
        var existingUsuario = await _context.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Documentos)
            .FirstOrDefaultAsync(u => u.Id == usuario.Id);

        if (existingUsuario != null)
        {
            // Atualiza as propriedades do usuário
            _context.Entry(existingUsuario).CurrentValues.SetValues(usuario);
            
            // Atualiza o endereço, se necessário
            if (usuario.Endereco != null)
            {
                _context.Entry(existingUsuario.Endereco).CurrentValues.SetValues(usuario.Endereco);
            }

            // Atualiza os documentos
            if (usuario.Documentos != null && usuario.Documentos.Any())
            {
                foreach (var documento in usuario.Documentos)
                {
                    var existingDocumento = existingUsuario.Documentos
                        .FirstOrDefault(d => d.Id == documento.Id);

                    if (existingDocumento != null)
                    {
                        _context.Entry(existingDocumento).CurrentValues.SetValues(documento);
                    }
                    else
                    {
                        existingUsuario.Documentos.Add(documento); // Adiciona novos documentos
                    }
                }
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();
        }

        return existingUsuario;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Busca o usuário pelo ID
        var usuario = await _context.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Documentos)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);  // Remove o usuário

            // Se tiver documentos, remove também
            if (usuario.Documentos != null && usuario.Documentos.Any())
            {
                _context.Documentos.RemoveRange(usuario.Documentos);
            }

            // Se tiver endereço, remove também
            if (usuario.Endereco != null)
            {
                _context.Enderecos.Remove(usuario.Endereco);
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }
}

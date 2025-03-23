using Microsoft.EntityFrameworkCore;

public class DocumentoRepository : IDocumentoRepository
{
    private readonly GestaoRhContext _context;

    public DocumentoRepository(GestaoRhContext context)
    {
        _context = context;
    }

    public async Task<Documento> CreateAsync(Documento documento)
    {
        await _context.Documentos.AddAsync(documento);
        await _context.SaveChangesAsync();
        return documento;
    }

    public async Task<Documento> GetByIdAsync(int id)
    {
        return await _context.Documentos
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Documento> UpdateAsync(Documento documento)
    {
        _context.Documentos.Update(documento);
        await _context.SaveChangesAsync();
        return documento;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var documento = await GetByIdAsync(id);
        if (documento == null) return false;

        _context.Documentos.Remove(documento);
        await _context.SaveChangesAsync();
        return true;
    }
}

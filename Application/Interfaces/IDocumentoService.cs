public interface IDocumentoService
{
    Task<Documento> CreateAsync(Documento documento);
    Task<Documento> GetByIdAsync(int id);
    Task<Documento> UpdateAsync(Documento documento);
    Task<bool> DeleteAsync(int id);
}

using AutoMapper;

public class DocumentoService : IDocumentoService
{
    private readonly IDocumentoRepository _documentoRepository;
    private readonly IMapper _mapper;

    public DocumentoService(IDocumentoRepository documentoRepository, IMapper mapper)
    {
        _documentoRepository = documentoRepository;
        _mapper = mapper;
    }

    public async Task<Documento> CreateAsync(Documento documento)
    {
        return await _documentoRepository.CreateAsync(documento);
    }

    public async Task<Documento> GetByIdAsync(int id)
    {
        return await _documentoRepository.GetByIdAsync(id);
    }

    public async Task<Documento> UpdateAsync(Documento documento)
    {
        return await _documentoRepository.UpdateAsync(documento);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _documentoRepository.DeleteAsync(id);
    }
}

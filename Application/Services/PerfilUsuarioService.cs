using AutoMapper;

public class PerfilUsuarioService : IPerfilUsuarioService
{
    private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;
    private readonly IMapper _mapper;

    public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository, IMapper mapper)
    {
        _perfilUsuarioRepository = perfilUsuarioRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PerfilUsuarioDto>> GetAllAsync()
    {
        var perfis = await _perfilUsuarioRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PerfilUsuarioDto>>(perfis);
    }

    public async Task<PerfilUsuarioDto> GetByIdAsync(int id)
    {
        var perfil = await _perfilUsuarioRepository.GetByIdAsync(id);
        return _mapper.Map<PerfilUsuarioDto>(perfil);
    }

    public async Task<PerfilUsuarioDto> AddAsync(PerfilUsuarioDto perfilUsuarioDto)
    {
        var perfil = _mapper.Map<PerfilUsuario>(perfilUsuarioDto);
        perfil = await _perfilUsuarioRepository.AddAsync(perfil);
        return _mapper.Map<PerfilUsuarioDto>(perfil);
    }

    public async Task<PerfilUsuarioDto> UpdateAsync(int id, PerfilUsuarioDto perfilUsuarioDto)
    {
        var perfilExistente = await _perfilUsuarioRepository.GetByIdAsync(id);
        if (perfilExistente == null) return null;

        _mapper.Map(perfilUsuarioDto, perfilExistente);
        await _perfilUsuarioRepository.UpdateAsync(perfilExistente);

        return _mapper.Map<PerfilUsuarioDto>(perfilExistente);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var perfil = await _perfilUsuarioRepository.GetByIdAsync(id);
        if (perfil == null) return false;

        await _perfilUsuarioRepository.DeleteAsync(perfil);
        return true;
    }
}

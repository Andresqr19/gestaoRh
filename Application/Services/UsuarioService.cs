using AutoMapper;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> AddAsync(UsuarioDto usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        var novoUsuario = await _usuarioRepository.CreateAsync(usuario);
        return _mapper.Map<UsuarioDto>(novoUsuario);
    }

    public async Task<UsuarioDto> GetByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
    }

    public async Task UpdateAsync(int id, UsuarioDto usuarioDto)
    {
        var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);

        if (usuarioExistente == null)
            throw new Exception("Usuário não encontrado.");

        // Mapeia os dados do DTO para a entidade Usuario
        _mapper.Map(usuarioDto, usuarioExistente);

        // Atualiza os documentos
        if (usuarioDto.Documentos != null && usuarioDto.Documentos.Any())
        {
            foreach (var documentoDto in usuarioDto.Documentos)
            {
                var documentoExistente = usuarioExistente.Documentos
                    .FirstOrDefault(d => d.Id == documentoDto.Id);

                if (documentoExistente != null)
                {
                    // Atualiza o documento existente
                    _mapper.Map(documentoDto, documentoExistente);
                }
                else
                {
                    // Adiciona um novo documento
                    usuarioExistente.Documentos.Add(_mapper.Map<Documento>(documentoDto));
                }
            }
        }

        // Atualiza o endereço
        if (usuarioDto.Endereco != null)
        {
            if (usuarioExistente.Endereco != null)
            {
                // Atualiza o endereço existente
                _mapper.Map(usuarioDto.Endereco, usuarioExistente.Endereco);
            }
            else
            {
                // Cria um novo endereço
                usuarioExistente.Endereco = _mapper.Map<Endereco>(usuarioDto.Endereco);
            }
        }

        // Atualiza o usuário no repositório
        await _usuarioRepository.UpdateAsync(usuarioExistente);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _usuarioRepository.DeleteAsync(id);
    }
}

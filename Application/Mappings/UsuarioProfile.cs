using AutoMapper;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioDto, Usuario>();
        CreateMap<EnderecoDto, Endereco>();
        CreateMap<DocumentosDto, Documento>();

        CreateMap<Usuario, UsuarioDto>();
        CreateMap<Endereco, EnderecoDto>();
        CreateMap<Documento, DocumentosDto>();
    }
}

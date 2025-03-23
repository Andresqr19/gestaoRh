using AutoMapper;
using gestaoRh.Api.DTOs;

public class PerfilUsuarioProfile : Profile
{
    public PerfilUsuarioProfile()
    {
        CreateMap<PerfilUsuarioDto, PerfilUsuario>();

        CreateMap<PerfilUsuario, PerfilUsuarioDto>();
    }
}

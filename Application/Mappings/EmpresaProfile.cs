using AutoMapper;
using gestaoRh.Api.DTOs;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<EmpresaDto, Empresa>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));

        CreateMap<EnderecoDto, Endereco>();

        CreateMap<Empresa, EmpresaDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));

        CreateMap<Endereco, EnderecoDto>();
    }
}

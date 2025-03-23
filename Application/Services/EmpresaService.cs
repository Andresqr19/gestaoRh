using gestaoRh.Api.DTOs;
using gestaoRh.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace gestaoRh.Application.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmpresaDto>> GetAllAsync()
    {
        var empresas = await _empresaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
    }

    public async Task<EmpresaDto?> GetByIdAsync(int id)
    {
        var empresa = await _empresaRepository.GetByIdAsync(id);
        return _mapper.Map<EmpresaDto>(empresa);
    }

    public async Task<EmpresaDto> AddAsync(EmpresaDto empresaDto)
    {
        var empresa = _mapper.Map<Empresa>(empresaDto);
        empresa = await _empresaRepository.AddAsync(empresa);
        return _mapper.Map<EmpresaDto>(empresa);
    }

    public async Task UpdateAsync(int id, EmpresaDto empresaDto)
    {
        var empresa = await _empresaRepository.GetByIdAsync(id);
        if (empresa == null) return;

        _mapper.Map(empresaDto, empresa);
        await _empresaRepository.UpdateAsync(empresa);
    }

    public async Task DeleteAsync(int id) =>
        await _empresaRepository.DeleteAsync(id);
}

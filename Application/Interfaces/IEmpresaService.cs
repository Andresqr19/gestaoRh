using gestaoRh.Api.DTOs;

public interface IEmpresaService
{
    Task<IEnumerable<EmpresaDto>> GetAllAsync();
    Task<EmpresaDto?> GetByIdAsync(int id);
    Task<EmpresaDto> AddAsync(EmpresaDto empresaDto);
    Task UpdateAsync(int id, EmpresaDto empresaDto);
    Task DeleteAsync(int id);
}

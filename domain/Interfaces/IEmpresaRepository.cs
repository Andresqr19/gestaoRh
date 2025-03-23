using gestaoRh.Api.DTOs;

namespace gestaoRh.Infrastructure.Repositories.Interfaces;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> GetAllAsync();
    Task<Empresa?> GetByIdAsync(int id);
    Task UpdateAsync(Empresa empresa);
    Task DeleteAsync(int id);
    Task<Empresa?> AddAsync(Empresa empresa);
}

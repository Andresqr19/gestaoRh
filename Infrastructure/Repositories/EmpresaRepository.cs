using gestaoRh.Api.DTOs;
using gestaoRh.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gestaoRh.Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly GestaoRhContext _context;

    public EmpresaRepository(GestaoRhContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Empresa>> GetAllAsync() =>
        await _context.Empresas
            .Include(e => e.Endereco) // Inclui o endereço na consulta
            .ToListAsync();

    public async Task<Empresa?> GetByIdAsync(int id) =>
        await _context.Empresas
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<Empresa> AddAsync(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task UpdateAsync(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa != null)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}

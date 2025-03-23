using gestaoRh.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace gestaoRh.Api.Controllers;

[ApiController]
[Route("api/empresas")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _empresaService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var empresa = await _empresaService.GetByIdAsync(id);
        return empresa != null ? Ok(empresa) : NotFound("Empresa não encontrada!");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmpresaDto empresaDto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var empresaCriada = await _empresaService.AddAsync(empresaDto);

    return CreatedAtAction(nameof(GetById), new { id = empresaCriada.Id }, empresaCriada);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmpresaDto empresaDto)
    {
        await _empresaService.UpdateAsync(id, empresaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _empresaService.DeleteAsync(id);
        return NoContent();
    }
}

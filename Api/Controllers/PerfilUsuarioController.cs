using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/perfil-usuario")]
public class PerfilUsuarioController : ControllerBase
{
    private readonly IPerfilUsuarioService _perfilUsuarioService;

    public PerfilUsuarioController(IPerfilUsuarioService perfilUsuarioService)
    {
        _perfilUsuarioService = perfilUsuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var perfis = await _perfilUsuarioService.GetAllAsync();
        return Ok(perfis);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var perfil = await _perfilUsuarioService.GetByIdAsync(id);
        if (perfil == null) return NotFound();
        return Ok(perfil);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PerfilUsuarioDto perfilUsuarioDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var perfilCriado = await _perfilUsuarioService.AddAsync(perfilUsuarioDto);
        return CreatedAtAction(nameof(GetById), new { id = perfilCriado.Id }, perfilCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PerfilUsuarioDto perfilUsuarioDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var perfilAtualizado = await _perfilUsuarioService.UpdateAsync(id, perfilUsuarioDto);
        if (perfilAtualizado == null) return NotFound();

        return Ok(perfilAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _perfilUsuarioService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioCriado = await _usuarioService.AddAsync(usuarioDto);
        return CreatedAtAction(nameof(GetById), new { id = usuarioCriado.Id }, usuarioCriado);
    }

    // GET: api/usuario/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetById(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto usuarioDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioExistente = await _usuarioService.GetByIdAsync(id);
        if (usuarioExistente == null)
            return NotFound();

        await _usuarioService.UpdateAsync(id, usuarioDto);
        return NoContent(); // 204 No Content
    }

    // DELETE: api/usuario/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null)
            return NotFound();

        await _usuarioService.DeleteAsync(id);
        return NoContent(); // 204 No Content
    }
}


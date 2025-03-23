using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/documentos")]
public class DocumentoController : ControllerBase
{
    private readonly IDocumentoService _documentoService;
    private readonly IMapper _mapper;

    public DocumentoController(IDocumentoService documentoService, IMapper mapper)
    {
        _documentoService = documentoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DocumentosDto documentosDto)
    {
        if (documentosDto == null)
            return BadRequest("Dados inválidos.");

        var documento = _mapper.Map<Documento>(documentosDto);
        var createdDocumento = await _documentoService.CreateAsync(documento);
        var responseDto = _mapper.Map<DocumentosDto>(createdDocumento);

        return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var documento = await _documentoService.GetByIdAsync(id);
        if (documento == null)
            return NotFound();

        var documentosDto = _mapper.Map<DocumentosDto>(documento);
        return Ok(documentosDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DocumentosDto documentosDto)
    {
        if (documentosDto == null || id != documentosDto.Id)
            return BadRequest("Dados inválidos.");

        var documento = _mapper.Map<Documento>(documentosDto);
        var updatedDocumento = await _documentoService.UpdateAsync(documento);
        if (updatedDocumento == null)
            return NotFound();

        return Ok(_mapper.Map<DocumentosDto>(updatedDocumento));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _documentoService.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}

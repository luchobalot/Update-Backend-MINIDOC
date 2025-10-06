using Microsoft.AspNetCore.Mvc;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioMinidocController : ControllerBase
    {
        private readonly IUsuarioMinidocService _usuarioService;
        private readonly ILogger<UsuarioMinidocController> _logger;

        public UsuarioMinidocController(IUsuarioMinidocService usuarioService, ILogger<UsuarioMinidocController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CreateUsuarioMinidocDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.CrearUsuarioAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuarioMinidoc }, usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error en creación de usuario.");
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UpdateUsuarioMinidocDTO dto)
        {
            if (id != dto.IdUsuarioMinidoc)
                return BadRequest("ID no coincide.");

            var usuario = await _usuarioService.UpdateAsync(dto);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuarioService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}

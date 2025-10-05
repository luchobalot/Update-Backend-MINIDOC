using Microsoft.AspNetCore.Mvc;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioMinidocController : ControllerBase
    {
        private readonly IUsuarioMinidocService _usuarioService;

        public UsuarioMinidocController(IUsuarioMinidocService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // ================================================
        // GET: api/UsuarioMinidoc
        // ================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioMinidoc>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        // ================================================
        // GET: api/UsuarioMinidoc/{id}
        // ================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioMinidoc>> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // ================================================
        // POST: api/UsuarioMinidoc
        // ================================================
        [HttpPost]
        public async Task<ActionResult<UsuarioMinidoc>> Post([FromBody] CreateUsuarioMinidocDTO dto)
        {
            try
            {
                var usuario = await _usuarioService.CrearUsuarioAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuarioMinidoc }, usuario);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión o respuesta desde AuthAPI
                return StatusCode(StatusCodes.Status502BadGateway, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Cualquier otro error inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "No se pudo crear el usuario.",
                    detalle = ex.Message
                });
            }
        }

        // ================================================
        // PUT: api/UsuarioMinidoc/{id}
        // ================================================
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioMinidoc>> Put(int id, [FromBody] UpdateUsuarioMinidocDTO dto)
        {
            if (id != dto.IdUsuarioMinidoc)
                return BadRequest("El id no coincide");

            var usuario = await _usuarioService.UpdateAsync(dto);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // ================================================
        // DELETE: api/UsuarioMinidoc/{id}
        // ================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _usuarioService.DeleteAsync(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

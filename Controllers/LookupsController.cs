using Microsoft.AspNetCore.Mvc;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.Lookups;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("jerarquias")]
        [ProducesResponseType(typeof(IEnumerable<JerarquiaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<JerarquiaDTO>>> GetJerarquias()
        {
            var result = await _lookupService.GetJerarquiasAsync();
            return Ok(result);
        }

        [HttpGet("cuerpos")]
        [ProducesResponseType(typeof(IEnumerable<CuerpoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CuerpoDTO>>> GetCuerpos()
        {
            var result = await _lookupService.GetCuerposAsync();
            return Ok(result);
        }

        [HttpGet("escalafones")]
        [ProducesResponseType(typeof(IEnumerable<EscalafonDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EscalafonDTO>>> GetEscalafones()
        {
            var result = await _lookupService.GetEscalafonesAsync();
            return Ok(result);
        }

        [HttpGet("tipos-clasificacion")]
        [ProducesResponseType(typeof(IEnumerable<TipoClasificacionDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoClasificacionDTO>>> GetTiposClasificacion()
        {
            var result = await _lookupService.GetTiposClasificacionAsync();
            return Ok(result);
        }

        [HttpGet("estados")]
        [ProducesResponseType(typeof(IEnumerable<EstadoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetEstados()
        {
            var result = await _lookupService.GetEstadosAsync();
            return Ok(result);
        }

        [HttpGet("destinos")]
        [ProducesResponseType(typeof(IEnumerable<DestinoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DestinoDTO>>> GetDestinos()
        {
            var result = await _lookupService.GetDestinosAsync();
            return Ok(result);
        }

        [HttpGet("niveles")]
        [ProducesResponseType(typeof(IEnumerable<NivelDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NivelDTO>>> GetNiveles()
        {
            var result = await _lookupService.GetNivelesAsync();
            return Ok(result);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(LookupsResponseDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<LookupsResponseDTO>> GetAll()
        {
            var lookups = await _lookupService.GetAllLookupsAsync();
            return Ok(lookups);
        }
    }
}

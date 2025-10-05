using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.Lookups;

namespace ProyectoBackendMINIDOC.Services.Interfaces
{
    public interface ILookupService
    {
        Task<IEnumerable<JerarquiaDTO>> GetJerarquiasAsync();
        Task<IEnumerable<CuerpoDTO>> GetCuerposAsync();
        Task<IEnumerable<EscalafonDTO>> GetEscalafonesAsync();
        Task<IEnumerable<TipoClasificacionDTO>> GetTiposClasificacionAsync();
        Task<IEnumerable<EstadoDTO>> GetEstadosAsync();
        Task<IEnumerable<DestinoDTO>> GetDestinosAsync();
        Task<IEnumerable<NivelDTO>> GetNivelesAsync();
        Task<LookupsResponseDTO> GetAllLookupsAsync();
    }
}

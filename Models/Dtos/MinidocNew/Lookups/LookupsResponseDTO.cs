namespace ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.Lookups
{
    public class LookupsResponseDTO
    {
        public IEnumerable<JerarquiaDTO> Jerarquias { get; set; } = new List<JerarquiaDTO>();
        public IEnumerable<CuerpoDTO> Cuerpos { get; set; } = new List<CuerpoDTO>();
        public IEnumerable<EscalafonDTO> Escalafones { get; set; } = new List<EscalafonDTO>();
        public IEnumerable<TipoClasificacionDTO> TiposClasificacion { get; set; } = new List<TipoClasificacionDTO>();
        public IEnumerable<EstadoDTO> Estados { get; set; } = new List<EstadoDTO>();
        public IEnumerable<DestinoDTO> Destinos { get; set; } = new List<DestinoDTO>();
        public IEnumerable<NivelDTO> Niveles { get; set; } = new List<NivelDTO>();
    }
}

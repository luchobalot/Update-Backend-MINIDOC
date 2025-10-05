using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.Lookups;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;

namespace ProyectoBackendMINIDOC.Mappers
{
    public static class LookupMapper
    {
        public static JerarquiaDTO ToDTO(Jerarquia entity) => new()
        {
            IdJerarquia = entity.IdJerarquia,
            Letra = entity.Letra,
            Detalle = entity.Detalle
        };

        public static CuerpoDTO ToDTO(Cuerpo entity) => new()
        {
            IdCuerpo = entity.IdCuerpo,
            Sigla = entity.Sigla,
            Detalle = entity.Detalle
        };

        public static EscalafonDTO ToDTO(Escalafon entity) => new()
        {
            IdEscalafon = entity.IdEscalafon,
            Letra = entity.Letra,
            Detalle = entity.Detalle
        };

        public static TipoClasificacionDTO ToDTO(TipoClasificacion entity) => new()
        {
            IdTipoClasificacion = entity.IdTipoClasificacion,
            Descripcion = entity.Descripcion
        };

        public static EstadoDTO ToDTO(Estado entity) => new()
        {
            IdEstado = entity.IdEstado,
            Descripcion = entity.Descripcion
        };

        public static DestinoDTO ToDTO(Destino entity) => new()
        {
            IdDestino = entity.IdDestino,
            Nombre = entity.Nombre,
            Cuatrigrama = entity.Cuatrigrama
        };

        public static NivelDTO ToDTO(Nivel entity) => new()
        {
            IdNivel = entity.IdNivel,
            Descripcion = entity.Descripcion
        };
    }
}

using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;

namespace ProyectoBackendMINIDOC.Repositories.Interfaces
{
    public interface ILookupRepository
    {
        Task<IEnumerable<Jerarquia>> GetJerarquiasAsync();
        Task<IEnumerable<Cuerpo>> GetCuerposAsync();
        Task<IEnumerable<Escalafon>> GetEscalafonesAsync();
        Task<IEnumerable<TipoClasificacion>> GetTiposClasificacionAsync();
        Task<IEnumerable<Estado>> GetEstadosAsync();
        Task<IEnumerable<Destino>> GetDestinosAsync();
        Task<IEnumerable<Nivel>> GetNivelesAsync();
    }
}

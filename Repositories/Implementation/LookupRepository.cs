using Microsoft.EntityFrameworkCore;
using ProyectoBackendMINIDOC.Data;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;
using ProyectoBackendMINIDOC.Repositories.Interfaces;

namespace ProyectoBackendMINIDOC.Repositories.Implementation
{
    public class LookupRepository : ILookupRepository
    {
        private readonly MinidocNewContext _context;

        public LookupRepository(MinidocNewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Jerarquia>> GetJerarquiasAsync() =>
    await _context.Jerarquias
        .AsNoTracking()
        .OrderBy(j => j.IdJerarquia)
        .ToListAsync();

        public async Task<IEnumerable<Cuerpo>> GetCuerposAsync() =>
            await _context.Cuerpos
                .AsNoTracking()
                .OrderBy(c => c.IdCuerpo)
                .ToListAsync();

        public async Task<IEnumerable<Escalafon>> GetEscalafonesAsync() =>
            await _context.Escalafones
                .AsNoTracking()
                .OrderBy(e => e.IdEscalafon)
                .ToListAsync();

        public async Task<IEnumerable<TipoClasificacion>> GetTiposClasificacionAsync() =>
            await _context.TiposClasificacion
                .AsNoTracking()
                .OrderBy(t => t.IdTipoClasificacion)
                .ToListAsync();

        public async Task<IEnumerable<Estado>> GetEstadosAsync() =>
            await _context.Estados
                .AsNoTracking()
                .OrderBy(e => e.IdEstado)
                .ToListAsync();

        public async Task<IEnumerable<Destino>> GetDestinosAsync() =>
            await _context.Destinos
                .AsNoTracking()
                .OrderBy(d => d.IdDestino)
                .ToListAsync();

        public async Task<IEnumerable<Nivel>> GetNivelesAsync() =>
            await _context.Niveles
                .AsNoTracking()
                .OrderBy(n => n.IdNivel)
                .ToListAsync();

            }
}

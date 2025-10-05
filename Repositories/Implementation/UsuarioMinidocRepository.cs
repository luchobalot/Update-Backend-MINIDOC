using Microsoft.EntityFrameworkCore;
using ProyectoBackendMINIDOC.Data;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;
using ProyectoBackendMINIDOC.Repositories.Interfaces;

namespace ProyectoBackendMINIDOC.Repositories.Implementation
{
    public class UsuarioMinidocRepository : IUsuarioMinidocRepository
    {
        private readonly MinidocNewContext _context;

        public UsuarioMinidocRepository(MinidocNewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioMinidoc>> GetAllAsync()
        {
            return await _context.UsuariosMinidoc
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UsuarioMinidoc?> GetByIdAsync(int id)
        {
            return await _context.UsuariosMinidoc
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.IdUsuarioMinidoc == id);
        }

        public async Task AddAsync(UsuarioMinidoc usuario)
        {
            _context.UsuariosMinidoc.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioMinidoc usuario)
        {
            _context.UsuariosMinidoc.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UsuarioMinidoc usuario)
        {
            _context.UsuariosMinidoc.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

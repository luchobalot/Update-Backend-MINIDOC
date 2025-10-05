using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;

namespace ProyectoBackendMINIDOC.Repositories.Interfaces
{
    public interface IUsuarioMinidocRepository
    {
        Task<IEnumerable<UsuarioMinidoc>> GetAllAsync();
        Task<UsuarioMinidoc?> GetByIdAsync(int id);
        Task AddAsync(UsuarioMinidoc usuario);
        Task UpdateAsync(UsuarioMinidoc usuario);
        Task DeleteAsync(UsuarioMinidoc usuario);
    }
}

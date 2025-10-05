using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;

namespace ProyectoBackendMINIDOC.Services.Interfaces
{
    public interface IUsuarioMinidocService
    {
        Task<IEnumerable<UsuarioMinidoc>> GetAllAsync();
        Task<UsuarioMinidoc?> GetByIdAsync(int id);
        Task<UsuarioMinidoc> CrearUsuarioAsync(CreateUsuarioMinidocDTO dto);
        Task<UsuarioMinidoc?> UpdateAsync(UpdateUsuarioMinidocDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

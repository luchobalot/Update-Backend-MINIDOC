using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;

namespace ProyectoBackendMINIDOC.Services.Interfaces
{
    public interface IAuthService
    {
        /// Crea el usuario en AuthAPI y devuelve su GUID (Id de AspNetUsers).
        /// Debe lanzar excepción si falla (no devolver Guid.Empty).
        Task<Guid> CrearUsuarioEnAuthAsync(CreateUsuarioMinidocDTO dto, Guid supervisorId);

    }
}

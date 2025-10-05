using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;
using ProyectoBackendMINIDOC.Repositories.Interfaces;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Services.Implementation
{
    public class UsuarioMinidocService : IUsuarioMinidocService
    {
        private readonly IUsuarioMinidocRepository _repository;
        private readonly IAuthService _authService;

        public UsuarioMinidocService(IUsuarioMinidocRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<IEnumerable<UsuarioMinidoc>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<UsuarioMinidoc?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<UsuarioMinidoc> CrearUsuarioAsync(CreateUsuarioMinidocDTO dto)
        {
            // 1) Crear en AuthAPI (si falla, lanza y NO se inserta en Minidoc)
            var idAuthUser = await _authService.CrearUsuarioEnAuthAsync(dto);

            // 2) Insertar en MINIDOC (recién ahora)
            var usuario = new UsuarioMinidoc
            {
                IdAuthUser        = idAuthUser,
                Logon             = dto.Logon,
                MatriculaRevista  = dto.MatriculaRevista,
                Apellido          = dto.Apellido,
                Nombre            = dto.Nombre,
                JerarquiaId       = dto.JerarquiaId,
                DestinoId         = dto.DestinoId,
                NivelId           = dto.NivelId,
                IdEscalafon       = dto.IdEscalafon,
                IdCuerpo          = dto.IdCuerpo,
                Confianza         = dto.Confianza,
                SuperConfianza    = dto.SuperConfianza,
                FechaCreacion     = DateTime.Now
            };

            await _repository.AddAsync(usuario);
            return usuario;
        }

        public async Task<UsuarioMinidoc?> UpdateAsync(UpdateUsuarioMinidocDTO dto)
        {
            var usuario = await _repository.GetByIdAsync(dto.IdUsuarioMinidoc);
            if (usuario == null) return null;

            usuario.MatriculaRevista = dto.MatriculaRevista;
            usuario.Apellido         = dto.Apellido;
            usuario.Nombre           = dto.Nombre;
            usuario.JerarquiaId      = dto.JerarquiaId;
            usuario.DestinoId        = dto.DestinoId;
            usuario.NivelId          = dto.NivelId;
            usuario.IdEscalafon      = dto.IdEscalafon;
            usuario.IdCuerpo         = dto.IdCuerpo;
            usuario.Confianza        = dto.Confianza;
            usuario.SuperConfianza   = dto.SuperConfianza;

            await _repository.UpdateAsync(usuario);
            return usuario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return false;

            await _repository.DeleteAsync(usuario);
            return true;
        }
    }
}

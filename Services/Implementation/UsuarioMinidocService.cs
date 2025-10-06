using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;
using ProyectoBackendMINIDOC.Repositories.Interfaces;
using ProyectoBackendMINIDOC.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ProyectoBackendMINIDOC.Services.Implementation
{
    public class UsuarioMinidocService : IUsuarioMinidocService
    {
        private readonly IUsuarioMinidocRepository _repository;
        private readonly IAuthService _authService;
        private readonly ILogger<UsuarioMinidocService> _logger;

        public UsuarioMinidocService(
            IUsuarioMinidocRepository repository,
            IAuthService authService,
            ILogger<UsuarioMinidocService> logger)
        {
            _repository = repository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<IEnumerable<UsuarioMinidoc>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<UsuarioMinidoc?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<UsuarioMinidoc> CrearUsuarioAsync(CreateUsuarioMinidocDTO dto)
        {
            try
            {
                _logger.LogInformation("🟢 Iniciando creación de usuario completo: {Logon}", dto.Logon);

                // 1️⃣ Crear usuario en AuthAPI
                var supervisorId = Guid.Parse("9f13a4fd-d650-433d-9c43-b5d70cd44186"); // id del usuario logueado o uno fijo de prueba
                _logger.LogInformation("Supervisor ID utilizado: {SupervisorId}", supervisorId);

                var idAuth = await _authService.CrearUsuarioEnAuthAsync(dto, supervisorId);
                _logger.LogInformation("✅ Usuario creado en AuthAPI con ID: {IdAuth}", idAuth);

                // 2️⃣ Crear usuario en MINIDOC
                var usuario = new UsuarioMinidoc
                {
                    IdAuthUser = idAuth,
                    Logon = dto.Logon,
                    MatriculaRevista = dto.MatriculaRevista,
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    JerarquiaId = dto.JerarquiaId,
                    DestinoId = dto.DestinoId,
                    NivelId = dto.NivelId,
                    IdEscalafon = dto.IdEscalafon,
                    IdCuerpo = dto.IdCuerpo,
                    IdTipoClasificacion = dto.IdTipoClasificacion,
                    Confianza = dto.Confianza,
                    SuperConfianza = dto.SuperConfianza,
                    FechaCreacion = DateTime.Now
                };

                await _repository.AddAsync(usuario);
                _logger.LogInformation("✅ Usuario guardado correctamente en Minidoc con ID {Id}", usuario.IdUsuarioMinidoc);

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error durante la creación de usuario. Se canceló el proceso.");
                throw new InvalidOperationException($"Error al crear usuario: {ex.Message}");
            }
        }

        public async Task<UsuarioMinidoc?> UpdateAsync(UpdateUsuarioMinidocDTO dto)
        {
            var usuario = await _repository.GetByIdAsync(dto.IdUsuarioMinidoc);
            if (usuario == null) return null;

            usuario.MatriculaRevista = dto.MatriculaRevista;
            usuario.Apellido = dto.Apellido;
            usuario.Nombre = dto.Nombre;
            usuario.JerarquiaId = dto.JerarquiaId;
            usuario.DestinoId = dto.DestinoId;
            usuario.NivelId = dto.NivelId;
            usuario.IdEscalafon = dto.IdEscalafon;
            usuario.IdCuerpo = dto.IdCuerpo;
            usuario.IdTipoClasificacion = dto.IdTipoClasificacion;
            usuario.Confianza = dto.Confianza;
            usuario.SuperConfianza = dto.SuperConfianza;

            await _repository.UpdateAsync(usuario);
            _logger.LogInformation("✏️ Usuario actualizado: {Id}", usuario.IdUsuarioMinidoc);

            return usuario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return false;

            await _repository.DeleteAsync(usuario);
            _logger.LogInformation("🗑️ Usuario eliminado: {Id}", id);

            return true;
        }
    }
}

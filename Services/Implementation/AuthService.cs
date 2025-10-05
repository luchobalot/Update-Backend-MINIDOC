using System.Net.Http.Json;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient; // BaseAddress se setea en Program.cs
        }

        public async Task<Guid> CrearUsuarioEnAuthAsync(CreateUsuarioMinidocDTO dto)
        {
            // Ajustá el path si tu endpoint real es otro:
            var endpoint = "/api/v1.0/users/register";

            var payload = new
            {
                username = dto.Logon,
                password = dto.Password,
                nombre = dto.Nombre,
                apellido = dto.Apellido
            };

            HttpResponseMessage resp;
            try
            {
                resp = await _httpClient.PostAsJsonAsync(endpoint, payload);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("AuthAPI no disponible.", ex);
            }

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"AuthAPI devolvió {((int)resp.StatusCode)}: {body}");
            }

            var result = await resp.Content.ReadFromJsonAsync<AuthResponse>();
            if (result == null || result.UserId == Guid.Empty)
                throw new InvalidOperationException("AuthAPI no devolvió un UserId válido.");

            return result.UserId;
        }

        private sealed class AuthResponse
        {
            public Guid UserId { get; set; }
            public string? Token { get; set; } // si tu AuthAPI también devuelve token
        }
    }
}

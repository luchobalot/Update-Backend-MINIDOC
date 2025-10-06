using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc;
using ProyectoBackendMINIDOC.Services.Interfaces;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace ProyectoBackendMINIDOC.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(HttpClient httpClient, ILogger<AuthService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> CrearUsuarioEnAuthAsync(CreateUsuarioMinidocDTO dto, Guid supervisorId)
        {
            var endpoint = $"/api/v1.0/users/{supervisorId}";

            var payload = new
            {
                logon = dto.Logon,
                password = dto.Password,
                passwordConfirmation = dto.PasswordConfirmation
            };

            try
            {
                _logger.LogInformation("📤 Enviando solicitud a AuthAPI ({Url})", _httpClient.BaseAddress + endpoint);

                // 🔹 Recuperar token JWT del request del frontend
                var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(authHeader))
                {
                    _logger.LogWarning("⚠️ No se encontró token JWT en el request del frontend.");
                    throw new InvalidOperationException("No se encontró sesión activa. Inicie sesión nuevamente.");
                }

                var token = authHeader.Replace("Bearer ", "").Trim();

                // 🔹 Limpiar headers previos y agregar token actual
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync(endpoint, payload);
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("❌ AuthAPI devolvió {Status}: {Body}", response.StatusCode, responseText);
                    throw new InvalidOperationException($"Error AuthAPI ({response.StatusCode}): {responseText}");
                }

                // 🔹 Leer la respuesta JSON real que devuelve AuthAPI
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (result == null || result.Id == Guid.Empty)
                {
                    _logger.LogError("❌ AuthAPI no devolvió un UserId válido. Respuesta: {Body}", responseText);
                    throw new InvalidOperationException("AuthAPI no devolvió un UserId válido.");
                }

                _logger.LogInformation("✅ Usuario creado en AuthAPI con ID {UserId}", result.Id);
                return result.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error al comunicarse con AuthAPI.");
                throw new InvalidOperationException("Error al comunicarse con AuthAPI.", ex);
            }
        }

        // 🔹 Modelo ajustado al formato real de la AuthAPI
        private sealed class AuthResponse
        {
            public Guid Id { get; set; }
            public string? UserName { get; set; }
        }
    }
}

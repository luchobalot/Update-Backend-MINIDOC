using System.ComponentModel.DataAnnotations;

namespace ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc
{
    public class CreateUsuarioMinidocDTO
    {
        [Required]
        public string Logon { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string PasswordConfirmation { get; set; } = string.Empty;

        [Required, StringLength(7)]
        public string MatriculaRevista { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int JerarquiaId { get; set; }

        public int? DestinoId { get; set; }

        [Required]
        public int NivelId { get; set; }

        public int? IdEscalafon { get; set; }

        public int? IdCuerpo { get; set; }

        public int? IdTipoClasificacion { get; set; }

        public bool Confianza { get; set; }

        public bool SuperConfianza { get; set; }
    }
}

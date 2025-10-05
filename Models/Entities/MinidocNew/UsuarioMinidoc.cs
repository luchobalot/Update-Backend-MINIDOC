using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("UsuarioMINIDOC", Schema = "minidocNEW")]
    public class UsuarioMinidoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioMinidoc { get; set; }

        [Required]
        public Guid IdAuthUser { get; set; }

        [Required, MaxLength(100)]
        public string Logon { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? MatriculaRevista { get; set; }

        [Required, MaxLength(150)]
        public string Apellido { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int JerarquiaId { get; set; }

        public int? DestinoId { get; set; }

        [Required]
        public int NivelId { get; set; }

        public int? IdEscalafon { get; set; }

        public int? IdCuerpo { get; set; }

        public int? IdTipoClasificacion { get; set; }

        [Required]
        public bool Confianza { get; set; }

        [Required]
        public bool SuperConfianza { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}

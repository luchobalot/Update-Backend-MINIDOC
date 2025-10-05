using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("TipoClasificacion", Schema = "minidocNEW")]
    public class TipoClasificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoClasificacion { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; } = string.Empty;
    }
}

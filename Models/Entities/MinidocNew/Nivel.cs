using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("Nivel", Schema = "minidocNEW")]
    public class Nivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNivel { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; } = string.Empty;
    }
}

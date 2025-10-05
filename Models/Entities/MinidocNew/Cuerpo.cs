using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("Cuerpo", Schema = "minidocNEW")]
    public class Cuerpo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuerpo { get; set; }

        [MaxLength(2)]
        public string? Sigla { get; set; }

        [MaxLength(50)]
        public string? Detalle { get; set; }
    }
}

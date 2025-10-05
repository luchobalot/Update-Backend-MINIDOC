using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("Escalafon", Schema = "minidocNEW")]
    public class Escalafon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEscalafon { get; set; }

        [MaxLength(4)]
        public string? Letra { get; set; }

        [MaxLength(50)]
        public string? Detalle { get; set; }
    }
}

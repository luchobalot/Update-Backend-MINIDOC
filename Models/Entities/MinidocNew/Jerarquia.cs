using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBackendMINIDOC.Models.Entities.MinidocNew
{
    [Table("Jerarquia", Schema = "minidocNEW")]
    public class Jerarquia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJerarquia { get; set; }

        [MaxLength(50)]
        public string? Letra { get; set; }

        [MaxLength(50)]
        public string? Detalle { get; set; }
    }
}

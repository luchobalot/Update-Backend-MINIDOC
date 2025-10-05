namespace ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc
{
    public class UpdateUsuarioMinidocDTO
    {
        public int IdUsuarioMinidoc { get; set; }

        public string MatriculaRevista { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public int JerarquiaId { get; set; }

        public int? DestinoId { get; set; }

        public int NivelId { get; set; }

        public int? IdEscalafon { get; set; }

        public int? IdCuerpo { get; set; }

        public int? IdTipoClasificacion { get; set; }

        public bool Confianza { get; set; }

        public bool SuperConfianza { get; set; }
    }
}

namespace ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.UsuarioMinidoc
{
    public class DeleteUsuarioMinidocDTO
    {
        public int IdUsuarioMinidoc { get; set; }
        public bool BorradoLogico { get; set; } = true;
    }
}

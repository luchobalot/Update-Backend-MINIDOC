using Microsoft.EntityFrameworkCore;

namespace ProyectoBackendMINIDOC.Data
{
    public partial class MinidocOldContext : DbContext
    {
        public MinidocOldContext(DbContextOptions<MinidocOldContext> options)
            : base(options)
        {
        }

        // No hay DbSets activos: este contexto queda disponible
        // solo para futuras consultas al esquema antiguo (dbo)
        // o para migraciones puntuales de datos.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se mantiene la configuración base de collation
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            // No hay entidades activas actualmente
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

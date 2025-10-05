using Microsoft.EntityFrameworkCore;
using ProyectoBackendMINIDOC.Models.Entities.MinidocNew;

namespace ProyectoBackendMINIDOC.Data
{
    public class MinidocNewContext : DbContext
    {
        public MinidocNewContext(DbContextOptions<MinidocNewContext> options) : base(options) { }

        // ==========================
        // DbSets principales
        // ==========================
        public DbSet<UsuarioMinidoc> UsuariosMinidoc { get; set; }
        public DbSet<Jerarquia> Jerarquias { get; set; }
        public DbSet<Cuerpo> Cuerpos { get; set; }
        public DbSet<Escalafon> Escalafones { get; set; }
        public DbSet<TipoClasificacion> TiposClasificacion { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Nivel> Niveles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==========================
            // Mapear tablas al esquema minidocNEW
            // ==========================
            modelBuilder.Entity<UsuarioMinidoc>().ToTable("UsuarioMINIDOC", "minidocNEW");
            modelBuilder.Entity<Jerarquia>().ToTable("Jerarquia", "minidocNEW");
            modelBuilder.Entity<Cuerpo>().ToTable("Cuerpo", "minidocNEW");
            modelBuilder.Entity<Escalafon>().ToTable("Escalafon", "minidocNEW");
            modelBuilder.Entity<TipoClasificacion>().ToTable("TipoClasificacion", "minidocNEW");
            modelBuilder.Entity<Estado>().ToTable("Estado", "minidocNEW");
            modelBuilder.Entity<Destino>().ToTable("Destino", "minidocNEW");
            modelBuilder.Entity<Nivel>().ToTable("Nivel", "minidocNEW");

            // ==========================
            // Relaciones (Foreign Keys)
            // ==========================
            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<Jerarquia>()
                .WithMany()
                .HasForeignKey(u => u.JerarquiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<Cuerpo>()
                .WithMany()
                .HasForeignKey(u => u.IdCuerpo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<Escalafon>()
                .WithMany()
                .HasForeignKey(u => u.IdEscalafon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<TipoClasificacion>()
                .WithMany()
                .HasForeignKey(u => u.IdTipoClasificacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<Nivel>()
                .WithMany()
                .HasForeignKey(u => u.NivelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioMinidoc>()
                .HasOne<Destino>()
                .WithMany()
                .HasForeignKey(u => u.DestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================
            // Configuración adicional
            // ==========================
            modelBuilder.Entity<UsuarioMinidoc>()
                .Property(u => u.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}

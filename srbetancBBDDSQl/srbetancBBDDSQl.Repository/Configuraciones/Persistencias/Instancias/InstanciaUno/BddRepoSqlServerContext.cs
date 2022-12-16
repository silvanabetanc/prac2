using BP.Comun.Centralizada.Interfaces;
using Microsoft.EntityFrameworkCore;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;

namespace srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno
{
    public class BddRepoSqlServerContext : DbContext
    {
        private readonly IPropiedadesApi _iPropiedadesApi;
        private readonly IConfiguracionCentralizada _iConfiguracionCentralizada;
        public BddRepoSqlServerContext(IPropiedadesApi iPropiedadesApi, IConfiguracionCentralizada iConfiguracionCentralizada)
        {
            _iPropiedadesApi = iPropiedadesApi;
            _iConfiguracionCentralizada = iConfiguracionCentralizada;
        }

        public BddRepoSqlServerContext(DbContextOptions<BddRepoSqlServerContext> options)
            : base(options)
        {

        }
        public virtual DbSet<FrmHistorialEvento> FrmHistorialEventos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(EConstantes.TagConexionInstanciaSql);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FrmHistorialEvento>(entity =>
            {
                entity.ToTable("FRM_HistorialEventos");

                entity.Property(e => e.AppId)
                    .HasMaxLength(128)
                    .HasColumnName("AppID");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.PackageId)
                    .HasMaxLength(256)
                    .HasColumnName("PackageID");
            });

        }
    }
}

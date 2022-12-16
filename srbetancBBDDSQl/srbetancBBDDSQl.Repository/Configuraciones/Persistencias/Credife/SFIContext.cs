using BP.API.Entidades.Excepciones;
using BP.Comun.Extensiones;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using srbetancBBDDSQl.API.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using System.Data;

namespace srbetancBBDDSQl.Repositorio.Configuraciones.Persistencias.BDDOrigen
{
    public partial class SFIContext : DbContext, IContextBdd
    {
        private readonly IPropiedadesApi? iPropiedadesApi;
        private readonly string BddStringConnection ="";
        private SqlConnection conn = new();

        public SFIContext()
        {

        }

        public SFIContext(IPropiedadesApi iPropiedadesApi)
        {
            this.iPropiedadesApi = iPropiedadesApi;
            BddStringConnection = EConstantes.URLBASEDATOSSFI;
        }

        public SFIContext(DbContextOptions<SFIContext> options) : base(options)
        { 
            Database.SetCommandTimeout(15);
        }

        public virtual DbSet<SegMovimientosExpediente> SegMovimientosExpedientes { get; set; } = null!;
        public virtual DbSet<SegProductosReferido> SegProductosReferidos { get; set; } = null!;
        public virtual DbSet<SegTransferenciasContable> SegTransferenciasContables { get; set; } = null!;


        public void Disconnect(IDbConnection con)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(BddStringConnection))
            {
                throw new CoreNegocioError(EConstantes.COD_ERROR_CADENA_CONEXION, EConstantes.DES_ERROR_CADENA_CONEXION, this.GetFirstName(), EConstantes.RECURSO_001,
                              iPropiedadesApi!.ConsultarCatalogo(EConstantes.TAGBACKEND_CONFIGURACION));
            }
            conn = new SqlConnection(BddStringConnection);
            return conn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(BddStringConnection))
            {
                throw new CoreNegocioError(EConstantes.COD_ERROR_CADENA_CONEXION, EConstantes.DES_ERROR_CADENA_CONEXION, this.GetFirstName(), EConstantes.RECURSO_001,
                              iPropiedadesApi!.ConsultarCatalogo(EConstantes.TAGBACKEND_CONFIGURACION));
            }
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.BddStringConnection, o => o.CommandTimeout(15));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

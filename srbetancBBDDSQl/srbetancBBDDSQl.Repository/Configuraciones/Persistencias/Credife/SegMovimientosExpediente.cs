using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace srbetancBBDDSQl.API.ProductosReferidos
{
    [Table("SEG_MOVIMIENTOS_EXPEDIENTES")]
    public partial class SegMovimientosExpediente
    {
        public SegMovimientosExpediente()
        {
            SegProductosReferidos = new HashSet<SegProductosReferido>();
        }

        [Key]
        [Column("SEC_MOVIMIENTO", TypeName = "numeric(18, 0)")]
        public decimal SecMovimiento { get; set; }
        /// <summary>
        /// Proceso del que viene el Detalle de Movimientos
        /// </summary>
        [Column("PROCESO")]
        [StringLength(125)]
        public string Proceso { get; set; } = null!;
        [Column("FECHA_CONSULTA", TypeName = "datetime")]
        public DateTime FechaConsulta { get; set; }
        [Column("EXPEDIENTE_SEGURO")]
        [StringLength(250)]
        public string ExpedienteSeguro { get; set; } = null!;
        [Column("PRODUCTO_COD")]
        [StringLength(10)]
        public string ProductoCod { get; set; } = null!;
        /// <summary>
        /// Fecha Transaccion en Bancs
        /// </summary>
        [Column("FECHA_TRANSACCION", TypeName = "datetime")]
        public DateTime FechaTransaccion { get; set; }
        [Column("TOTAL_IVA_TRANSACCION", TypeName = "decimal(18, 2)")]
        public decimal TotalIvaTransaccion { get; set; }
        /// <summary>
        /// Jornal del Movimiento en Bancs
        /// </summary>
        [Column("JOURNAL_TRANSACCION")]
        [StringLength(250)]
        public string JournalTransaccion { get; set; } = null!;
        [Column("TIPO_TRANSACCION")]
        [StringLength(10)]
        public string TipoTransaccion { get; set; } = null!;
        /// <summary>
        /// Concepto del Movimiento en Bancs
        /// </summary>
        [Column("CONCEPTO_TRANSACCION")]
        [StringLength(250)]
        public string? ConceptoTransaccion { get; set; }
        [Column("CODIGO_TRANSACCION")]
        [StringLength(250)]
        public string? CodigoTransaccion { get; set; }
        [Column("SALDO_DISPONIBLE", TypeName = "decimal(18, 2)")]
        public decimal? SaldoDisponible { get; set; }
        [Column("CODIGO_AGENCIA")]
        [StringLength(10)]
        public string? CodigoAgencia { get; set; }
        [Column("NOMBRE_AGENCIA")]
        [StringLength(250)]
        public string? NombreAgencia { get; set; }
        [Column("DIRECCION_AGENCIA")]
        [StringLength(250)]
        public string? DireccionAgencia { get; set; }
        [Column("ESTADO_CUADRE")]
        [StringLength(10)]
        public string? EstadoCuadre { get; set; }
        [Column("FECHA_CUADRE", TypeName = "datetime")]
        public DateTime? FechaCuadre { get; set; }

        [InverseProperty("SecMovimientoNavigation")]
        public virtual ICollection<SegProductosReferido> SegProductosReferidos { get; set; }
    }
}

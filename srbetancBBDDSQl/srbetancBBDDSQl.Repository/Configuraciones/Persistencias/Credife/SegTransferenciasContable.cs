using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace srbetancBBDDSQl.API.ProductosReferidos
{
    [Table("SEG_TRANSFERENCIAS_CONTABLES")]
    public partial class SegTransferenciasContable
    {
        public SegTransferenciasContable()
        {
            SegProductosReferidos = new HashSet<SegProductosReferido>();
        }

        [Key]
        [Column("SEC_TRANSFERENCIA", TypeName = "numeric(18, 0)")]
        public decimal SecTransferencia { get; set; }
        /// <summary>
        /// Proceso del que se realiza la transferencia
        /// </summary>
        [Column("PROCESO")]
        [StringLength(125)]
        public string Proceso { get; set; } = null!;
        [Column("FECHA_TRANSFERENCIA", TypeName = "datetime")]
        public DateTime FechaTransferencia { get; set; }
        [Column("EXPEDIENTE_SEGURO")]
        [StringLength(250)]
        public string ExpedienteSeguro { get; set; } = null!;
        [Column("PRODUCTO_COD")]
        [StringLength(10)]
        public string ProductoCod { get; set; } = null!;
        [Column("CUENTA_TRANSFERENCIA")]
        [StringLength(250)]
        public string CuentaTransferencia { get; set; } = null!;
        /// <summary>
        /// Fecha Transaccion en Bancs
        /// </summary>
        [Column("FECHA_TRANSFERENCIA_BANCS", TypeName = "datetime")]
        public DateTime FechaTransferenciaBancs { get; set; }
        [Column("TOTAL_IVA_TRANSFERENCIA", TypeName = "decimal(18, 2)")]
        public decimal TotalIvaTransferencia { get; set; }
        [Column("ID_TRANSFERENCIA")]
        [StringLength(250)]
        public string IdTransferencia { get; set; } = null!;
        /// <summary>
        /// Jornal de la transferencia en Bancs
        /// </summary>
        [Column("JOURNAL_TRANSFERENCIA")]
        [StringLength(250)]
        public string JournalTransferencia { get; set; } = null!;
        /// <summary>
        /// Concepto de la transferencia en Bancs
        /// </summary>
        [Column("CONCEPTO_TRANSFERENCIA")]
        [StringLength(250)]
        public string? ConceptoTransferencia { get; set; }

        [InverseProperty("SecTransferenciaNavigation")]
        public virtual ICollection<SegProductosReferido> SegProductosReferidos { get; set; }
    }
}

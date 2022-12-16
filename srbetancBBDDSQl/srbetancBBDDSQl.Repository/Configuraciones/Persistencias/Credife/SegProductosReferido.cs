using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace srbetancBBDDSQl.API.ProductosReferidos
{
    [Table("SEG_PRODUCTOS_REFERIDOS")]
    public partial class SegProductosReferido
    {
        [Key]
        [Column("ID", TypeName = "numeric(18, 0)")]
        public decimal Id { get; set; }
        /// <summary>
        /// SECUENCIAL DE LA ORDEN POR USUARIO
        /// </summary>
        [Column("SEC_REFERIMIENTO", TypeName = "numeric(18, 0)")]
        public decimal SecReferimiento { get; set; }
        [Column("USUARIO")]
        [StringLength(10)]
        public string Usuario { get; set; } = null!;
        /// <summary>
        /// PRODUCTO GENERADO INTERNAMENTE PARA RELACIONAR INTERVINIENTES
        /// </summary>
        [Column("PRODUCTO_ID")]
        public int ProductoId { get; set; }
        /// <summary>
        /// CODIGO PROPORCIONADO POR NOVA
        /// </summary>
        [Column("REFERIMIENTO_ID")]
        [StringLength(100)]
        public string ReferimientoId { get; set; } = null!;
        /// <summary>
        /// CATALOGO TIPO 1
        /// </summary>
        [Column("PRODUCTO_COD")]
        [StringLength(10)]
        public string ProductoCod { get; set; } = null!;
        /// <summary>
        /// CATALOGO TIPO 2
        /// </summary>
        [Column("COBERTURA_COD")]
        [StringLength(10)]
        public string CoberturaCod { get; set; } = null!;
        /// <summary>
        /// CATALOGO TIPO 3
        /// </summary>
        [Column("MODALIDAD_COD")]
        [StringLength(10)]
        public string ModalidadCod { get; set; } = null!;
        /// <summary>
        /// CATALOGO TIPO 4
        /// </summary>
        [Column("FRECUENCIA_COD")]
        [StringLength(10)]
        public string FrecuenciaCod { get; set; } = null!;
        [Column("TOTAL_SIN_IVA", TypeName = "decimal(18, 2)")]
        public decimal? TotalSinIva { get; set; }
        [Column("TOTAL_IVA", TypeName = "decimal(18, 2)")]
        public decimal? TotalIva { get; set; }
        /// <summary>
        /// CATALOGO TIPO 5
        /// </summary>
        [Column("TIPO_CUENTA_COD")]
        [StringLength(10)]
        public string? TipoCuentaCod { get; set; }
        [Column("CTA_REFERIDO")]
        [StringLength(20)]
        public string? CtaReferido { get; set; }
        [Column("ENFERMEDAD")]
        [StringLength(250)]
        public string? Enfermedad { get; set; }
        [Column("ESTADO_PRODUCTO")]
        [StringLength(10)]
        public string EstadoProducto { get; set; } = null!;
        [Column("FECHA_MODIFICACION", TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        [Column("USUARIO_MODIFICACION")]
        [StringLength(10)]
        public string? UsuarioModificacion { get; set; }
        [Column("FECHA_EMISION", TypeName = "datetime")]
        public DateTime? FechaEmision { get; set; }
        [Column("USUARIO_EMISION")]
        [StringLength(10)]
        public string? UsuarioEmision { get; set; }
        /// <summary>
        /// CATALOGO TIPO 18
        /// </summary>
        [Column("FLUJO_COBRO")]
        [StringLength(10)]
        public string? FlujoCobro { get; set; }
        /// <summary>
        /// FECHA EN LA QUE SE REALIZA EL COBRO DEL SEGURO
        /// </summary>
        [Column("FECHA_COBRO", TypeName = "datetime")]
        public DateTime? FechaCobro { get; set; }
        /// <summary>
        /// FECHA BANCS EN LA QUE SE REALIZA EL COBRO DEL SEGURO
        /// </summary>
        [Column("FECHA_BANCS_COBRO", TypeName = "datetime")]
        public DateTime? FechaBancsCobro { get; set; }
        /// <summary>
        /// OPERACION DE LA CUAL SE REALIZA EL COBRO DEL SEGURO
        /// </summary>
        [Column("OPERACION_COBRO")]
        [StringLength(250)]
        public string? OperacionCobro { get; set; }
        /// <summary>
        /// JOURNLA BANCS CON EL QUE SE REALIZA EL COBRO DEL SEGURO
        /// </summary>
        [Column("JOURNAL_COBRO")]
        [StringLength(250)]
        public string? JournalCobro { get; set; }
        [Column("FECHA_CONSULTA_COBRO", TypeName = "datetime")]
        public DateTime? FechaConsultaCobro { get; set; }
        [Column("FLUJO_CONSULTA_COBRO")]
        [StringLength(10)]
        public string? FlujoConsultaCobro { get; set; }
        [Column("CONCEPTO_CONSULTA_COBRO")]
        [StringLength(250)]
        public string? ConceptoConsultaCobro { get; set; }
        [Column("CODIGO_PAIS_NEGOCIO")]
        [StringLength(10)]
        public string? CodigoPaisNegocio { get; set; }
        [Column("CODIGO_PROVINCIA_NEGOCIO")]
        [StringLength(10)]
        public string? CodigoProvinciaNegocio { get; set; }
        [Column("CODIGO_CIUDAD_NEGOCIO")]
        [StringLength(10)]
        public string? CodigoCiudadNegocio { get; set; }
        [Column("DIRECCION_NEGOCIO")]
        [StringLength(250)]
        public string? DireccionNegocio { get; set; }
        [Column("SEC_MOVIMIENTO", TypeName = "numeric(18, 0)")]
        public decimal? SecMovimiento { get; set; }
        [Column("ESTADO_CUADRE")]
        [StringLength(10)]
        public string? EstadoCuadre { get; set; }
        [Column("FECHA_CUADRE", TypeName = "datetime")]
        public DateTime? FechaCuadre { get; set; }
        [Column("OBSERVACIONES_CUADRE")]
        [StringLength(250)]
        public string? ObservacionesCuadre { get; set; }
        [Column("SEC_TRANSFERENCIA", TypeName = "numeric(18, 0)")]
        public decimal? SecTransferencia { get; set; }
        [Column("ESTADO_TRANSFERENCIA")]
        [StringLength(10)]
        public string? EstadoTransferencia { get; set; }
        [Column("FECHA_TRANSFERENCIA", TypeName = "datetime")]
        public DateTime? FechaTransferencia { get; set; }
        [Column("OBSERVACIONES_TRANSFERENCIA")]
        [StringLength(250)]
        public string? ObservacionesTransferencia { get; set; }

        [ForeignKey("SecMovimiento")]
        [InverseProperty("SegProductosReferidos")]
        public virtual SegMovimientosExpediente? SecMovimientoNavigation { get; set; }
        [ForeignKey("SecTransferencia")]
        [InverseProperty("SegProductosReferidos")]
        public virtual SegTransferenciasContable? SecTransferenciaNavigation { get; set; }
    }
}

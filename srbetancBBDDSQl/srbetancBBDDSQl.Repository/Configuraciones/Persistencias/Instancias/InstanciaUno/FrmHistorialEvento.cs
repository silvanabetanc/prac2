using System.ComponentModel.DataAnnotations;

namespace srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno
{
    public class FrmHistorialEvento
    {
        [Key]
        public string PackageId { get; set; } = null!;
        public string AppId { get; set; } = null!;
        public DateTime FechaHora { get; set; }
    }
}

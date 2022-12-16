using BP.API.Entidades;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;

namespace srbetancBBDDSQl.Test.Utilitarios.Instancias.InstanciaUno
{
    public class DataSalida
    {
        public EFrmHistorialEventos _HistoricoEventos;
        public DataSalida()
        {
            _HistoricoEventos = new EFrmHistorialEventos
            {
                HistorialEventos = new List<EFrmHistorialEvento>
                { new EFrmHistorialEvento
                    {
                        AppId = "uno",
                        PackageId = "dos",
                        FechaHora = DateTime.Now,
                    }
                }
            };
        }

        public ERespuesta<EFrmHistorialEventos> ObtenerDatos()
        {
            var respuesta = new ERespuesta<EFrmHistorialEventos>();
            respuesta.BodyOut = _HistoricoEventos;
            return respuesta;
        }
    }
}

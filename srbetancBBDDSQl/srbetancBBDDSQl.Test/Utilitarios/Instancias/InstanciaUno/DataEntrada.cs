using BP.API.Entidades;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;

namespace srbetancBBDDSQl.Test.Utilitarios.Instancias.InstanciaUno
{
    public class DataEntrada
    {
        public EEntrada<EHistorialEvento> _HistoricoEvento;
        public DataEntrada()
        {
            _HistoricoEvento = new EEntrada<EHistorialEvento>
            {
                HeaderIn = new EHeader
                {

                    Dispositivo = "01010101010101010101010101010101",
                    Empresa = "0010",
                    Canal = "02",
                    Medio = "020007",
                    Aplicacion = "00669",
                    Agencia = "aad",
                    TipoTransaccion = "202026101",
                    Geolocalizacion = "1232",
                    Usuario = "USINTERT",
                    Ip = "10.0.94.126",
                    RequestIp = "",
                    FechaHora = "202104151505451252",
                    Sesion = "ASDASD77R01YH",
                    Unicidad = "123",
                    Guid = "3F2504E04F8911D39A0C0305E82C3302",
                    Filler = "",
                    Idioma = "es-EC",
                    IdCliente = "0908020753",
                    TipoIdCliente = "0001"
                },
                BodyIn = new EHistorialEvento
                {
                    AppId = "uno",
                    PackageId = "uno"
                }
            };
        }
    }
}

using BP.Comun.Centralizada.Entidades;
using BP.Comun.Centralizada.Interfaces;
using BP.Comun.Extensiones;
using BP.Comun.Propiedades;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;

namespace srbetancBBDDSQl.Repository.Configuraciones.Centralizada
{
    public class ConfiguradorCentralizada : IConfiguradorCentralizada
    {

        private readonly Propiedades propiedadesCentralizada;
        private readonly IPropiedadesApi iPropiedadesApi;
        public ConfiguradorCentralizada(IPropiedadesApi iPropiedadesApi)
        {
            propiedadesCentralizada = new Propiedades(Constantes.RutaConfiguracion);
            this.iPropiedadesApi = iPropiedadesApi;
        }
        #region PARÁMETROS QUE SE LEEN DESDE EL ARCHIVO DE CONFIGURACIÓN DE LA API
        public bool AutoCarga()
        {
            return iPropiedadesApi.ConsultarApi(Constantes.TagAutoCarga).ToBool();
        }

        public string CodigoAplicacion()
        {
            return iPropiedadesApi.ConsultarApi(Constantes.TagCodigoAplicacion);
        }
        public int Reintentos()
        {
            return iPropiedadesApi.ConsultarApi(Constantes.TagReintentos).ToInt();
        }
        public string DirectorioLogs()
        {
            return null;
        }
        #endregion PARÁMETROS QUE SE LEEN DESDE EL ARCHIVO DE CONFIGURACIÓN DE LA API


        #region PARÁMETROS PROPIOS DE ARCHIVO GENÉRICO DE CONFIGURACIÓN CENTRALIZADA /opt/app-root/configs/centralizada/centralizada.json
        public int TimeOut()
        {
            return propiedadesCentralizada.Get(Constantes.TagTimeOut).ToInt();
        }
        public string UrlWsCodigo()
        {
            return propiedadesCentralizada.Get(Constantes.TagUrlWsCodigo);
        }
        public string UrlWsConfiguracion()
        {
            return propiedadesCentralizada.Get(Constantes.TagUrlWsConfiguracion);
        }
        #endregion PARÁMETROS PROPIOS DE ARCHIVO GENÉRICO DE CONFIGURACIÓN CENTRALIZADA
    }
}


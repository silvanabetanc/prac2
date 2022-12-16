using BP.Comun.Centralizada.Interfaces;
using BP.Comun.Extensiones;
using BP.EventBus.Interfaces;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;

namespace srbetancBBDDSQl.Repository.Configuraciones.Kafka
{
    public class ConfiguracionKafka : IConfiguradorEventBus
    {
        private readonly IPropiedadesApi _iPropiedadesApi;
        private readonly IConfiguracionCentralizada _iConfiguracionCentralizada;
        public ConfiguracionKafka(IPropiedadesApi iPropiedadesApi, IConfiguracionCentralizada iConfiguracionCentralizada)
        {
            this._iPropiedadesApi = iPropiedadesApi;
            this._iConfiguracionCentralizada = iConfiguracionCentralizada;
        }

        public string IdGrupo()
        {
            return null;
        }

        public string Servidores()
        {
            string tags = _iPropiedadesApi.ConsultarApi("TagsServersKafka");

            string[] valores = tags.Split(EConstantes.Coma);

            IList<string> servidores = new List<string>();

            Array.ForEach(valores, valor =>
            {
                servidores.Add(_iConfiguracionCentralizada.ConsultarTag(valor));
            });

            return string.Join(EConstantes.Coma, servidores);
        }

        public int TimeOut()
        {
            return _iPropiedadesApi.ConsultarApi("TimeoutKafka").ToInt();
        }

        public int TimeOutConsumer()
        {
            return 0;
        }

        public int TimeOutProducer()
        {
            return _iPropiedadesApi.ConsultarApi("TimeoutKafka").ToInt();
        }

        public string Topico()
        {
            return null;
        }

        bool IConfiguradorEventBus.ActivaLog()
        {
            return false;
        }

        bool IConfiguradorEventBus.EnableDeliveryReports()
        {
            return false;
        }

        bool IConfiguradorEventBus.EnableLogConnectionClose()
        {
            return false;
        }

        string IConfiguradorEventBus.RutaLog()
        {
            return string.Empty;
        }
    }
}

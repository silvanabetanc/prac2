using BP.API.Entidades.Excepciones;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.EventBus.Entidades;
using BP.EventBus.Interfaces;
using srbetancBBDDSQl.Domain.Interfaces.Kafka;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srbetancBBDDSQl.Repository.Configuraciones.Kafka
{
    /// <summary>
    /// Clase para producir el mensaje genérico en el kafka
    /// </summary>
    public class RepositorioGenerico : IRepositorioGenerico
    {
        private readonly IPropiedadesApi _iPropiedadesApi;
        private readonly IKafkaProducer _iProducer;
        public RepositorioGenerico(IPropiedadesApi iPropiedadesApi, IKafkaProducer iProducer)
        {
            _iPropiedadesApi = iPropiedadesApi;
            _iProducer = iProducer;
        }

        /// <summary>
        /// Genera el mensaje en el kafka
        /// </summary>
        /// <param name="topico"></param>
        /// <param name="mensaje"></param>
        [LogExcepcion]
        public void GenerarMensajeProducer(string topico, string mensaje)
        {
            topico = $"{_iPropiedadesApi.InicialTopico()}{topico}";
            Task<ProducerResult> task = _iProducer.ExecuteAsync(topico, null, mensaje);
            task.Wait();

            if (task.Result.IsException)
            {
                throw new CoreExcepcion(this.GetFirstName(), EConstantes.Recurso201, _iPropiedadesApi.BackendKafka(), task.Result.Exception);
            }
        }
    }
}

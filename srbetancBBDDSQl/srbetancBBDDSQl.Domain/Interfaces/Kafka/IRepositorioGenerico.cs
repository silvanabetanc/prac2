namespace srbetancBBDDSQl.Domain.Interfaces.Kafka
{
    public interface IRepositorioGenerico
    {
        /// <summary>
        /// Método de la interfaz para la generación del mensaje
        /// </summary>
        /// <param name="topico"></param>
        /// <param name="mensaje"></param>
        void GenerarMensajeProducer(string topico, string mensaje);
    }
}

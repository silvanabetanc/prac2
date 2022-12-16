namespace srbetancBBDDSQl.Domain.Interfaces.Propiedades
{
    public interface IPropiedadesApi
    {
        string ConsultarApi(string key);
        string ConsultarCatalogo(string propiedad);
        string BackendOpenShift();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int PausaBackgroundService();

        /// <summary>
        /// Obtiene el nombre inicial para el tópico de Kafka
        /// </summary>
        /// <returns></returns>
        string InicialTopico();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string BackendKafka();
    }
}

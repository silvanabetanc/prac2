using BP.Comun.Extensiones;
using BP.Comun.Propiedades;
using BP.Comun.Propiedades.Entidades;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;

namespace srbetancBBDDSQl.Repository.Configuraciones.Api
{
    public class PropiedadesApi : IPropiedadesApi
    {

        private readonly Propiedades _configuracionCatalogos;
        private readonly Propiedades _configuracionApi;

        /// <summary>
        /// Constructror de la Clase con la lectura del archivo 
        /// </summary>
        public PropiedadesApi()
        {
            // carga archivo de catalogos
            _configuracionCatalogos = new Propiedades(Constantes.DirectorioCatalogos);

            // Carga del Archivo de Configuracion
            _configuracionApi = new Propiedades(string.Format(Constantes.DirectorioMicroservicio, this.GetFirstName().ToLower()));

        }

        #region Consulta de Catalogos y Configuracion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ConsultarApi(string key)
        {
            return _configuracionApi.Get(key);
        }

        /// <summary>
        ///  Obtiene dato catalogo segun propiedad 
        /// </summary>
        /// <param name="propiedad"></param>
        /// <returns></returns>
        public string ConsultarCatalogo(string propiedad)
        {
            return _configuracionCatalogos.Get(propiedad);
        }

        /// <summary>
        /// Obtiene codigo BackendOpenShift
        /// </summary>
        /// <returns></returns>
        public string BackendOpenShift()
        {
            return _configuracionCatalogos.Get(EConstantes.TagBackendOpenShift);
        }

        /// <summary>
        /// Pausa BackgroundServices
        /// </summary>
        /// <returns></returns>
        public int PausaBackgroundService()
        {
            return _configuracionApi.Get("PausaBGS").ToInt();
        }

        /// <summary>
        /// BackendKafka
        /// </summary>
        /// <returns></returns>
        public string BackendKafka()
        {
            return _configuracionCatalogos.Get("KAFKA");
        }

        /// <summary>
        /// Permite obtener el nombre inicial del tópico
        /// </summary>
        /// <returns></returns>
        public string InicialTopico()
        {
            return _configuracionApi.Get("TopicoInicial");
        }


        #endregion

    }
}

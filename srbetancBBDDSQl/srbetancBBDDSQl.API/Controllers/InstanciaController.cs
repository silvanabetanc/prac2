using BP.API.Constantes;
using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.API.Entidades.Extensiones;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;
using System.Net;

namespace srbetancBBDDSQl.API.Controllers
{
    #region DEFINICION DE VERSION DE API

    [ApiVersion("1")]

    #endregion DEFINICION DE VERSION DE API FIN

    [Route(Controlador.RutaVersion)]
    [ApiController]
    public class InstanciaController : ControllerBase
    {
        private readonly IPropiedadesApi _iPropiedadesApi;
        private readonly IInstanciaUnoInfraestructura _iInstanciaUnoInfraestructura;

        public InstanciaController(IPropiedadesApi iPropiedadesApi,
            IInstanciaUnoInfraestructura iInstanciaUnoInfraestructura)
        {
            _iPropiedadesApi = iPropiedadesApi;
            _iInstanciaUnoInfraestructura = iInstanciaUnoInfraestructura;
        }

        #region ConsultarInstancia01 
        /// <summary>
        /// Metodo GET para consultar la estructura de entrada que se usara en el servicio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(EConstantes.Recurso001)]
        [Loggable]
        public IActionResult ConsultarInstancia01()
        {
            return Ok(new EEntrada<EHistorialEvento>(new EHeader(), new EHistorialEvento()));
        }

        /// <summary>
        /// Metodo POST para consultar los datos de una instancia
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EConstantes.Recurso001)]
        [Loggable]
        public async Task<IActionResult> ConsultarInstancia01(EEntrada<EHistorialEvento> entrada)
        {
            EError error = new EError(this.GetFirstName(), EConstantes.Recurso001, _iPropiedadesApi.ConsultarCatalogo(EConstantes.TagBackendOpenShift));

            ERespuesta<EFrmHistorialEventos> salida = new ERespuesta<EFrmHistorialEventos>(entrada?.HeaderIn, new EFrmHistorialEventos(), error);

            try
            {
                return (await _iInstanciaUnoInfraestructura.EjecutarConsultarInstancia(entrada)).Match(
                    Left => StatusCode(HttpStatusCode.BadRequest.ToInt(), salida.AgregarError(Left)),
                    Right => Ok(Right));
            }
            catch (CoreNegocioError negocioError)
            {
                negocioError.ProcesarError(salida);
                return Ok(salida);
            }
            catch (Exception excepcion)
            {
                excepcion.ProcesarError(salida);
            }
            return Ok(salida);
        }

        /// Metodo POST para consultar los datos de un cliente
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EConstantes.Recurso002)]
        [Loggable]
        public async Task<IActionResult> CrearInstancia02(EEntrada<EHistorialEvento> entrada)
        {
            EError error = new EError(this.GetFirstName(), EConstantes.Recurso002, _iPropiedadesApi.ConsultarCatalogo(EConstantes.TagBackendOpenShift));

            ERespuesta<EFrmHistorialEvento> salida = new ERespuesta<EFrmHistorialEvento>(entrada?.HeaderIn, new EFrmHistorialEvento(), error);

            try
            {
                return (await _iInstanciaUnoInfraestructura.EjecutarCrearInstancia(entrada)).Match(
                    Left => StatusCode(HttpStatusCode.BadRequest.ToInt(), salida.AgregarError(Left)),
                    Right => Ok(Right));
            }
            catch (CoreNegocioError negocioError)
            {
                negocioError.ProcesarError(salida);
                return Ok(salida);
            }
            catch (Exception excepcion)
            {
                excepcion.ProcesarError(salida);
            }
            return Ok(salida);
        }
        #endregion ConsultarInstancia01 
    }
}

using BP.API.Constantes;
using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.API.Entidades.Extensiones;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using Microsoft.AspNetCore.Mvc;
using srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using System.Net;

namespace srbetancBBDDSQl.API.Controllers
{
    [ApiVersion("1")]
    [Route(Controlador.RutaVersion)]
    [ApiController]
    public class srbetancController : ControllerBase
    {

        private readonly IPropiedadesApi iPropiedadesApi;
        private readonly IProductosReferidosInfraestructura iProductosReferidosInfraestructura;

        public srbetancController(IPropiedadesApi iPropiedadesApi,
            IProductosReferidosInfraestructura iProductosReferidosInfraestructura)
        {
            this.iPropiedadesApi = iPropiedadesApi;
            this.iProductosReferidosInfraestructura = iProductosReferidosInfraestructura;
        }

      
        /// <summary>
        /// Metodo GET para consultar la estructura de entrada que se usara en el servicio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(EConstantes.Recurso001)]
        [Loggable]
        public IActionResult ConsultarProductosReferidos01()
        {
            return Ok(new EEntrada<EProductosReferidos>(new EHeader(), new EProductosReferidos()));
        }

        /// <summary>
        /// Metodo POST para consultar los datos de una instancia
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EConstantes.Recurso001)]
        [Loggable]
        public async Task<IActionResult> ConsultarProductosReferidos01(EEntrada<EProductosReferidos> entrada)
        {
            EError error = new EError(this.GetFirstName(), EConstantes.Recurso001, iPropiedadesApi.ConsultarCatalogo(EConstantes.TagBackendOpenShift));

            ERespuesta<EFrmHistorialEventos> salida = new ERespuesta<EFrmHistorialEventos>(entrada?.HeaderIn, new EFrmHistorialEventos(), error);

            try
            {
                return (await iProductosReferidosInfraestructura.ConsultarProductosReferidos(entrada)).Match(
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
    }
}

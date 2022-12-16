using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.Functional;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;
using srbetancBBDDSQl.Infrastructure.Validaciones;
using System.Reflection;

namespace srbetancBBDDSQl.Infrastructure.Instancias.InstanciaUno
{
    public class InstanciaUnoInfraestructura : IInstanciaUnoInfraestructura
    {
        private readonly IInstanciaUnoRepositorio _iInstanciaUnoRepositorio;
        public InstanciaUnoInfraestructura(IInstanciaUnoRepositorio iInstanciaUnoRepositorio)
        {
            _iInstanciaUnoRepositorio = iInstanciaUnoRepositorio;
        }

        [Loggable]
        public async Task<Either<EError, ERespuesta<EFrmHistorialEventos>>> EjecutarConsultarInstancia(EEntrada<EHistorialEvento> entrada)
        {
            var consultarValidacion = new ValidateEBasicoTransaccion();
            var validationResult = await consultarValidacion.ValidateAsync(entrada);

            if (!validationResult.IsValid)
            {
                var falla = validationResult.Errors.First();
                throw new CoreNegocioError(falla.ErrorCode, falla.ErrorMessage, this.GetFirstName(), MethodBase.GetCurrentMethod().DeclaringType.Name, "");
            }
            return await _iInstanciaUnoRepositorio.EjecutarConsultarInstancia(entrada);
        }

        public async Task<Either<EError, ERespuesta<EFrmHistorialEvento>>> EjecutarCrearInstancia(EEntrada<EHistorialEvento> entrada)
        {
            var consultarValidacion = new ValidateEBasicoTransaccion();
            var validationResult = await consultarValidacion.ValidateAsync(entrada);

            if (!validationResult.IsValid)
            {
                var falla = validationResult.Errors.First();
                throw new CoreNegocioError(falla.ErrorCode, falla.ErrorMessage, this.GetFirstName(), MethodBase.GetCurrentMethod().DeclaringType.Name, "");
            }
            return await _iInstanciaUnoRepositorio.EjecutarCrearInstancia(entrada);
        }
    }
}

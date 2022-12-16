using BP.API.Entidades;
using BP.Comun.Logs.Base.Handlers;
using BP.Functional;
using srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using srbetancBBDDSQl.Entity.ProductosReferidos.Salida;

namespace srbetancBBDDSQl.Infrastructure.ProductosReferidos
{
    public class ProductosReferidosInfraestructura : IProductosReferidosInfraestructura
    {
        public readonly IProductosReferidosRepositorio iProductosReferidosRepositorio;
        public readonly IPropiedadesApi iPropiedadesApi;

        public ProductosReferidosInfraestructura(IProductosReferidosRepositorio iProductosReferidosRepositorio,IPropiedadesApi iPropiedadesApi)
        {
            this.iProductosReferidosRepositorio = iProductosReferidosRepositorio;
            this.iPropiedadesApi = iPropiedadesApi;
        }

        [Loggable]
        public async Task<Either<EError, ERespuesta<EFrmProductosReferidos<EFrmProductoReferido>>>> ConsultarProductosReferidos(EEntrada<EProductosReferidos> entrada)
        {
            //var consultarValidacion = new ValidateEBasicoTransaccion();
            //var validationResult = await consultarValidacion.ValidateAsync(entrada);

            //if (!validationResult.IsValid)
            //{
            //    var falla = validationResult.Errors.First();
            //    throw new CoreNegocioError(falla.ErrorCode, falla.ErrorMessage, this.GetFirstName(), MethodBase.GetCurrentMethod().DeclaringType.Name, "");
            //}
            return await iProductosReferidosRepositorio.ConsultarProductosReferidos(entrada);
        }
    }
}

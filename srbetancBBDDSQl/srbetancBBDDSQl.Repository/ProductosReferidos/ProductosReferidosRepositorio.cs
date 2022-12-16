using BP.API.Entidades;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.Functional;
using srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using srbetancBBDDSQl.Entity.ProductosReferidos.Salida;
using srbetancBBDDSQl.Repositorio.Configuraciones.Persistencias.BDDOrigen;
using srbetancBBDDSQl.Repository.Excepcciones;

namespace srbetancBBDDSQl.Repository.ProductosReferidos
{
    public class ProductosReferidosRepositorio : IProductosReferidosRepositorio
    {
        private readonly IPropiedadesApi iPropiedadesApi;
        private readonly IWrapperDbContextCd iWrapperDbContextCd;

        public ProductosReferidosRepositorio(IPropiedadesApi iPropiedadesApi, IWrapperDbContextCd iWrapperDbContextCd)
        {
            this.iPropiedadesApi = iPropiedadesApi;
            this.iWrapperDbContextCd = iWrapperDbContextCd;
        }

        [Loggable]
        public async Task<Either<EError, ERespuesta<EFrmProductosReferidos<EFrmProductoReferido>>>> ConsultarProductosReferidos(EEntrada<EProductosReferidos> entrada)
        {
            EFrmProductosReferidos< EFrmProductoReferido> eFrmProductosReferidos = new EFrmProductosReferidos<EFrmProductoReferido>();
            var context = iWrapperDbContextCd.CreateContext(iPropiedadesApi);
            try
            {
                var resultado = await iWrapperDbContextCd.BuscaDatos(context, entrada);
                if (resultado.IsNotNull() && resultado.Count() > EConstantes.Zero)
                {
                    //resultado.ForEach(item =>
                    //{
                    //    EFrmProductoReferido frmProductoReferido = new EFrmProductoReferido
                    //    {
                    //        CoberturaCod = item.CoberturaCod,
                    //        ProductoCod = item.ProductoCod,
                    //        ModalidadCod = item.ModalidadCod,
                    //        ReferimientoId = item.ReferimientoId
                    //    };
                    //    eFrmProductosReferidos.ProductosReferidos.Add(frmProductoReferido);
                    //});
                    eFrmProductosReferidos.ProductosReferidos = resultado;
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion(EConstantes.ValExpCodigo, ex.Message, this.GetFirstName(), EConstantes.Recurso001, EConstantes.BackendBddRepositorioSql, ex);
            }
            finally
            {
                iWrapperDbContextCd.DisposeBdd(context);
            }
            return new ERespuesta<EFrmProductosReferidos<EFrmProductoReferido>>
            {
                HeaderOut = entrada.HeaderIn,
                BodyOut = new EFrmProductosReferidos<EFrmProductoReferido>
                {
                    ProductosReferidos = eFrmProductosReferidos.ProductosReferidos
                },
                Error = new EError(this.GetFirstName(), EConstantes.Recurso001, iPropiedadesApi.ConsultarCatalogo(EConstantes.BackendOpenShift))
                {
                    MensajeNegocio = string.Empty
                }
            };
        }
    }
}

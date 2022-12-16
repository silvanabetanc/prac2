using BP.API.Entidades;
using BP.Functional;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using srbetancBBDDSQl.Entity.ProductosReferidos.Salida;

namespace srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos
{
    public interface IProductosReferidosRepositorio
    {
        Task<Either<EError, ERespuesta<EFrmProductosReferidos<EFrmProductoReferido>>>> ConsultarProductosReferidos(EEntrada<EProductosReferidos> entrada);
    }
}

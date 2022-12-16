using BP.API.Entidades;
using srbetancBBDDSQl.API.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using srbetancBBDDSQl.Entity.ProductosReferidos.Salida;

namespace srbetancBBDDSQl.Repositorio.Configuraciones.Persistencias.BDDOrigen
{
    public interface IWrapperDbContextCd
    {
        
       // Task<List<SegProductosReferido>> BuscaDatos(SFIContext context, EEntrada<EProductosReferidos> entrada);
        Task<List<EFrmProductoReferido>> BuscaDatos(SFIContext context, EEntrada<EProductosReferidos> entrada);
        
        SFIContext CreateContext(IPropiedadesApi iPropiedadesApi);
        void DisposeBdd(SFIContext db);
    }
}

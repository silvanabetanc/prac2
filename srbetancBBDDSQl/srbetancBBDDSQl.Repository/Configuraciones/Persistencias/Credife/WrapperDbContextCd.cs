using BP.API.Entidades;
using Microsoft.EntityFrameworkCore;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity.ProductosReferidos.Entrada;
using srbetancBBDDSQl.Entity.ProductosReferidos.Salida;

namespace srbetancBBDDSQl.Repositorio.Configuraciones.Persistencias.BDDOrigen
{
    public class WrapperDbContextCd : IWrapperDbContextCd
    {
        //public virtual async Task<List<SegProductosReferido>> BuscaDatos(SFIContext context, EEntrada<EProductosReferidos> entrada)
        //{
        //    var result = context.SegProductosReferidos.ToList();
        //    return result;
        //}

        public virtual async Task<List<EFrmProductoReferido>> BuscaDatos(SFIContext context, EEntrada<EProductosReferidos> entrada)
        {
            var result = await (from a in context.SegProductosReferidos
                          join b in context.SegMovimientosExpedientes on a.SecMovimiento equals b.SecMovimiento
                          join c in context.SegTransferenciasContables on a.SecTransferencia equals c.SecTransferencia 
                          select new EFrmProductoReferido()
                          {
                              ReferimientoId = a.ReferimientoId,
                              ProductoCod = a.ProductoCod,
                              CoberturaCod = a.CoberturaCod,
                              ModalidadCod = a.ModalidadCod
                          }).ToListAsync();
            return result;
        }

        public SFIContext CreateContext(IPropiedadesApi iPropiedadesApi)
        {
            return new SFIContext(iPropiedadesApi);
        }

        public void DisposeBdd(SFIContext db)
        {
            db.Database.CloseConnection();
            if (db != null)
                db.Dispose();
        }
      

    }
}

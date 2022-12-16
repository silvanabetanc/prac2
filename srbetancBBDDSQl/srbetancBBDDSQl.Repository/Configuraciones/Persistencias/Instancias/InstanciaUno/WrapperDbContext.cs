using BP.API.Entidades;
using BP.Comun.Centralizada.Interfaces;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;

namespace srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno
{
    public class WrapperDbContext : IWrapperDbContext
    {
        public virtual BddRepoSqlServerContext CreateContext(IPropiedadesApi iPropiedadesApi, IConfiguracionCentralizada iConfiguracionCentralizada)
        {
            return new BddRepoSqlServerContext(iPropiedadesApi, iConfiguracionCentralizada);
        }
        public virtual async Task<List<FrmHistorialEvento>> BuscaDatos(BddRepoSqlServerContext bdd,
            EEntrada<EHistorialEvento> entrada)
        {
            var result = bdd.FrmHistorialEventos.ToList();
            return result;
        }
        public virtual async Task<FrmHistorialEvento> InsertarDatos(BddRepoSqlServerContext bdd,
            EEntrada<EHistorialEvento> entrada)
        {
            FrmHistorialEvento frmHistorialEvento = new FrmHistorialEvento();
            frmHistorialEvento.FechaHora = DateTime.Now;
            frmHistorialEvento.AppId = entrada.BodyIn.AppId;
            frmHistorialEvento.PackageId = entrada.BodyIn.PackageId;

            bdd.FrmHistorialEventos.Add(frmHistorialEvento);
            await bdd.SaveChangesAsync();
            return frmHistorialEvento;
        }
        public void DisposeBdd(BddRepoSqlServerContext bdd)
        {
            if (bdd != null)
                bdd.Dispose();
        }
    }
}

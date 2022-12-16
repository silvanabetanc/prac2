using BP.API.Entidades;
using BP.Comun.Centralizada.Interfaces;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;

namespace srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno
{
    public interface IWrapperDbContext
    {
        Task<List<FrmHistorialEvento>> BuscaDatos(BddRepoSqlServerContext bdd, EEntrada<EHistorialEvento> entrada);
        BddRepoSqlServerContext CreateContext(IPropiedadesApi iPropiedadesApi, IConfiguracionCentralizada iConfiguracionCentralizada);
        void DisposeBdd(BddRepoSqlServerContext bdd);
        Task<FrmHistorialEvento> InsertarDatos(BddRepoSqlServerContext bdd, EEntrada<EHistorialEvento> entrada);
    }
}
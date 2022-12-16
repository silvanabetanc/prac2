using BP.API.Entidades;
using BP.Functional;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;

namespace srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno
{
    public interface IInstanciaUnoInfraestructura
    {
        Task<Either<EError, ERespuesta<EFrmHistorialEventos>>> EjecutarConsultarInstancia(EEntrada<EHistorialEvento> entrada);
        Task<Either<EError, ERespuesta<EFrmHistorialEvento>>> EjecutarCrearInstancia(EEntrada<EHistorialEvento> entrada);
    }
}

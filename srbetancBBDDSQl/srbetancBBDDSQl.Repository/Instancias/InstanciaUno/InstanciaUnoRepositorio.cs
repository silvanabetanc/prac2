using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.Comun.Centralizada.Interfaces;
using BP.Comun.Extensiones;
using BP.Functional;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Domain.Interfaces.Kafka;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;
using srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno;

namespace srbetancBBDDSQl.Repository.Instancias.InstanciaUno
{
    public class InstanciaUnoRepositorio : IInstanciaUnoRepositorio
    {
        private readonly IPropiedadesApi _iPropiedadesApi;
        private readonly IConfiguracionCentralizada _iConfiguracionCentralizada;
        private readonly IWrapperDbContext _WrapperDbContext;
        private readonly IRepositorioGenerico _iRepositorioGenerico;
        public InstanciaUnoRepositorio(IPropiedadesApi iPropiedadesApi, IConfiguracionCentralizada iConfiguracionCentralizada, IWrapperDbContext wrapper, IRepositorioGenerico iRepositorioGenerico)
        {
            _iConfiguracionCentralizada = iConfiguracionCentralizada;
            _iPropiedadesApi = iPropiedadesApi;
            _WrapperDbContext = wrapper;
            _iRepositorioGenerico = iRepositorioGenerico;
        }
        public async Task<Either<EError, ERespuesta<EFrmHistorialEventos>>> EjecutarConsultarInstancia(EEntrada<EHistorialEvento> entrada)
        {
            EFrmHistorialEventos eHistorialEventos = new EFrmHistorialEventos();
            var context = _WrapperDbContext.CreateContext(_iPropiedadesApi, _iConfiguracionCentralizada);
            try
            {
                var resultado = await _WrapperDbContext.BuscaDatos(context, entrada);
                if (resultado.IsNotNull() && resultado.Count() > EConstantes.Zero)
                {
                    resultado.ForEach(item =>
                    {
                        EFrmHistorialEvento frmHistorialEventos = new EFrmHistorialEvento
                        {
                            AppId = item.AppId,
                            PackageId = item.AppId,
                            FechaHora = item.FechaHora
                        };
                        eHistorialEventos.HistorialEventos.Add(frmHistorialEventos);
                    });

                }
            }
            catch (Exception ex)
            {
                throw new CoreExcepcion(EConstantes.ValExpCodigo, ex.Message, this.GetFirstName(), EConstantes.Recurso001, EConstantes.BackendBddRepositorioSql, ex);
            }
            finally
            {
                _WrapperDbContext.DisposeBdd(context);
            }
            return new ERespuesta<EFrmHistorialEventos>
            {
                HeaderOut = entrada.HeaderIn,
                BodyOut = new EFrmHistorialEventos
                {
                    HistorialEventos = eHistorialEventos.HistorialEventos
                },
                Error = new EError(this.GetFirstName(), EConstantes.Recurso001, _iPropiedadesApi.ConsultarCatalogo(EConstantes.BackendOpenShift))
                {
                    MensajeNegocio = string.Empty
                }
            };
        }

        public async Task<Either<EError, ERespuesta<EFrmHistorialEvento>>> EjecutarCrearInstancia(EEntrada<EHistorialEvento> entrada)
        {
            EFrmHistorialEvento eHistorialEvento = new EFrmHistorialEvento();
            var context = _WrapperDbContext.CreateContext(_iPropiedadesApi, _iConfiguracionCentralizada);
            try
            {
                var resultado = await _WrapperDbContext.InsertarDatos(context, entrada);
                if (resultado.IsNotNull())
                {
                    _iRepositorioGenerico.GenerarMensajeProducer(entrada.HeaderIn.Filler, entrada.SerializeJson());
                    EFrmHistorialEvento frmHistorialEvento = new EFrmHistorialEvento
                    {
                        AppId = resultado.AppId,
                        PackageId = resultado.AppId,
                        FechaHora = resultado.FechaHora
                    };
                    eHistorialEvento = frmHistorialEvento;


                }
                return new ERespuesta<EFrmHistorialEvento>
                {
                    HeaderOut = entrada.HeaderIn,
                    BodyOut = eHistorialEvento,
                    Error = new EError(this.GetFirstName(), EConstantes.Recurso002, _iPropiedadesApi.ConsultarCatalogo(EConstantes.BackendOpenShift))
                    {
                        MensajeNegocio = string.Empty
                    }
                };
            }
            catch (Exception e)
            {
                throw new CoreExcepcion(EConstantes.ValExpCodigo, e.Message, this.GetFirstName(), EConstantes.Recurso001, EConstantes.BackendBddRepositorioSql, e);
            }
            finally
            {
                _WrapperDbContext.DisposeBdd(context);
            }
        }
    }
}

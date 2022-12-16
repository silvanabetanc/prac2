using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.Comun.Centralizada.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Domain.Interfaces.Kafka;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno;
using srbetancBBDDSQl.Repository.Instancias.InstanciaUno;
using srbetancBBDDSQl.Test.Utilitarios.Instancias.InstanciaUno;

namespace srbetancBBDDSQl.Test.RepositorioTest.Instancias.InstanciaUno
{
    public class InstanciaUnoRepositorioTest
    {
        private Mock<IPropiedadesApi> _mockIPropiedadesApi;
        private Mock<IConfiguracionCentralizada> _mockIConfiguracionCentralizada;
        private IInstanciaUnoRepositorio _iInstanciaUnoRepositorio;
        private Mock<IWrapperDbContext> _mockWrapperDbContext;
        private Mock<IRepositorioGenerico> _iGenericoRepositorio;
        private BddRepoSqlServerContext _BddRepoSqlServerContext;
        private DbContextOptions<BddRepoSqlServerContext> _bdContextOptions;
        [OneTimeSetUp]
        public void Setup()
        {
            _mockIPropiedadesApi = new Mock<IPropiedadesApi>();
            _mockIConfiguracionCentralizada = new Mock<IConfiguracionCentralizada>();
            _iGenericoRepositorio = new Mock<IRepositorioGenerico>();
            _mockIPropiedadesApi.Setup(x => x.ConsultarApi(EConstantes.BackendOpenShift)).Returns(EConstantes.BackendOpenShift);

            _bdContextOptions = new DbContextOptionsBuilder<BddRepoSqlServerContext>().UseInMemoryDatabase("FirmaElectronica").Options;
            _mockWrapperDbContext = new Mock<IWrapperDbContext>();

            _BddRepoSqlServerContext = new BddRepoSqlServerContext(_bdContextOptions);
            _BddRepoSqlServerContext.FrmHistorialEventos.Add(new FrmHistorialEvento
            {
                AppId = "uno",
                PackageId = "uno",
                FechaHora = DateTime.Now
            });
            _BddRepoSqlServerContext.SaveChanges();
            _mockWrapperDbContext.Setup(x => x.CreateContext(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object)).Returns(_BddRepoSqlServerContext);

        }

        [Test]
        public void Ejecutar_Consultar_Instancia_Retorna_ListaObjetos()
        {
            //Arrange
            DataEntrada entrada = new DataEntrada();
            _mockWrapperDbContext.Setup(x => x.BuscaDatos(It.IsAny<BddRepoSqlServerContext>(), It.IsAny<EEntrada<EHistorialEvento>>())).ReturnsAsync(_BddRepoSqlServerContext.FrmHistorialEventos.ToList());
            InstanciaUnoRepositorio _iInstanciaUnoRepositorio2 = new InstanciaUnoRepositorio(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object, _mockWrapperDbContext.Object, _iGenericoRepositorio.Object);
            //Act
            var respuesta = _iInstanciaUnoRepositorio2.EjecutarConsultarInstancia(entrada._HistoricoEvento);
            //Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);

            WrapperDbContext wp = new WrapperDbContext();
            Assert.DoesNotThrow(() => wp.CreateContext(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object));
        }

        [Test]
        public void Obtener_Consulta_Instacia_Retorna_ErrorObjeto()
        {
            // Arrange
            DataEntrada _dataEntrada = new DataEntrada();
            _mockWrapperDbContext.Setup(x => x.BuscaDatos(It.IsAny<BddRepoSqlServerContext>(), It.IsAny<EEntrada<EHistorialEvento>>()))
                .Throws(new CoreExcepcion("", "", "", new Exception(string.Empty)));
            _iInstanciaUnoRepositorio = new InstanciaUnoRepositorio(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object, _mockWrapperDbContext.Object, _iGenericoRepositorio.Object);
            //Act 
            var respuesta = _iInstanciaUnoRepositorio.EjecutarConsultarInstancia(_dataEntrada._HistoricoEvento);
            //Assert
            Assert.ThrowsAsync<CoreExcepcion>(async () => await respuesta);
        }

        [Test]
        public void CrearInstancia_Retorna_ListaObjetos()
        {
            //Arrange
            DataEntrada entrada = new DataEntrada();
            _mockWrapperDbContext.Setup(x => x.InsertarDatos(It.IsAny<BddRepoSqlServerContext>(), It.IsAny<EEntrada<EHistorialEvento>>())).ReturnsAsync(_BddRepoSqlServerContext.FrmHistorialEventos.FirstOrDefault());
            _iInstanciaUnoRepositorio = new InstanciaUnoRepositorio(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object, _mockWrapperDbContext.Object, _iGenericoRepositorio.Object);
            //Act
            var respuesta = _iInstanciaUnoRepositorio.EjecutarCrearInstancia(entrada._HistoricoEvento);
            //Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }

        [Test]
        public void Crear_Instacia_Retorna_ErrorObjeto()
        {
            // Arrange
            DataEntrada _dataEntrada = new DataEntrada();
            _mockWrapperDbContext.Setup(x => x.InsertarDatos(It.IsAny<BddRepoSqlServerContext>(), It.IsAny<EEntrada<EHistorialEvento>>()))
                .Throws(new CoreExcepcion("", "", "", new Exception(string.Empty)));
            _iInstanciaUnoRepositorio = new InstanciaUnoRepositorio(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object, _mockWrapperDbContext.Object, _iGenericoRepositorio.Object);
            //Act 
            var respuesta = _iInstanciaUnoRepositorio.EjecutarCrearInstancia(_dataEntrada._HistoricoEvento);
            //Assert
            Assert.ThrowsAsync<CoreExcepcion>(async () => await respuesta);
        }

        [Test]
        public void Crear_WrapperDbContext_Instancia_Retorna_ListaObjetos()
        {

            //Arrange
            WrapperDbContext wp = new WrapperDbContext();
            //Act

            //Assert
            Assert.DoesNotThrow(() => wp.CreateContext(_mockIPropiedadesApi.Object, _mockIConfiguracionCentralizada.Object));
        }

        [Test]
        public void Crear_WrapperDbContex_Consulta_Instacia_Retorna_ErrorObjeto()
        {
            //Arrange
            WrapperDbContext wp = new WrapperDbContext();
            DataEntrada entrada = new DataEntrada();
            //Act
            var respuesta = wp.BuscaDatos(_BddRepoSqlServerContext, entrada._HistoricoEvento);
            //Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }

        [Test]
        public void Crear_WrapperDbContex_Crear_Instacia_Retorna_ErrorObjeto()
        {
            //Arrange
            WrapperDbContext wp = new WrapperDbContext();
            DataEntrada entrada = new DataEntrada();
            entrada._HistoricoEvento.BodyIn.PackageId = "cuatro";
            //Act
            var respuesta = wp.InsertarDatos(_BddRepoSqlServerContext, entrada._HistoricoEvento);
            //Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }
    }
}

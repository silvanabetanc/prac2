using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using Moq;
using NUnit.Framework;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Salida;
using srbetancBBDDSQl.Infrastructure.Instancias.InstanciaUno;
using srbetancBBDDSQl.Test.Utilitarios.Instancias.InstanciaUno;

namespace srbetancBBDDSQl.Test.InfrastructuraTest.Instancias.InstanciaUno
{
    public class ConsultarInstanciaUnoInfraestructuraTest
    {
        private Mock<IInstanciaUnoRepositorio> _mockiInstanciaUnoRepositorio;

        private IInstanciaUnoInfraestructura _iInstanciaUnoInfraestructura;

        [SetUp]
        public void Setup()
        {
            _mockiInstanciaUnoRepositorio = new Mock<IInstanciaUnoRepositorio>();
            _iInstanciaUnoInfraestructura = new InstanciaUnoInfraestructura(_mockiInstanciaUnoRepositorio.Object);
            _mockiInstanciaUnoRepositorio.Setup(x => x.EjecutarConsultarInstancia(It.IsAny<EEntrada<EHistorialEvento>>())).ReturnsAsync(It.IsAny<ERespuesta<EFrmHistorialEventos>>());
        }

        [Test]
        public void Obtener_Consulta_Instacia_Retorna_ListaObjeto()
        {
            // Arrange
            DataEntrada _dataEntrada = new DataEntrada();
            //Act 
            var respuesta = _iInstanciaUnoInfraestructura.EjecutarConsultarInstancia(_dataEntrada._HistoricoEvento);
            //Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }
        [Test]
        public void Obtener_Consulta_Instacia_Retorna_ErrorObjeto()
        {
            // Arrange
            DataEntrada _dataEntrada = new DataEntrada();
            _dataEntrada._HistoricoEvento.HeaderIn = null;
            //Act 
            var respuesta = _iInstanciaUnoInfraestructura.EjecutarConsultarInstancia(_dataEntrada._HistoricoEvento);
            //Assert
            Assert.ThrowsAsync<CoreNegocioError>(async () => await respuesta);
        }
    }
}

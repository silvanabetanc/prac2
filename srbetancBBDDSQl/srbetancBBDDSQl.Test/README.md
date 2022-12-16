# Information
Implementacion de test para realizar pruebas unitarias de la capa repository e infraestructure.

	srbetancBBDDSQl.Test						
						|
						InfraestructuraTest
						|
						RepositorioTest
						|
						Utilitarios
						
													
# Documentation
InfraestructuraTest: Pruebas unitarias de la capa infraestructure.

RepositorioTest: Pruebas unitarias de la capa repository.

Utilitarios: Se definen las clases con datos de entrada y salida que se van a usar en las pruebas unitarias.


# Build 
ConsultarInstanciaUnoInfraestructuraTest.cs : Pruebas Unitarias de la capa Infraestructure. 

ConsultarInstanciaUnoRepositorioTest.cs, CrearInstanciaUnoRepositorioTest.cs: Pruebas Unitarias de la capa Repository. 

DataEntrada.cs : Se definen las entradas que se van a usar en las pruebas unitarias.

DataSalida.cs : Se definen las salidas que se van a usar en las pruebas unitarias.


# Nuget Packages
1.  Microsoft.EntityFrameworkCore.InMemory(6.0.10)
2.  Microsoft.NET.Test.Sdk(17.1.0)
3.  Moq(4.18.2)
4.  NUnit(3.13.3)
5.  NUnit3TestAdapter(4.2.1)
6.  NUnit.Analyzers(3.3.0)
7.  coverlet.collector(3.1.2)
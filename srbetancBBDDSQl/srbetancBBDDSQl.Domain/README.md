# Information
Dominio: se determina las interfaces a implementar

	WSServicioBase.Domain
						|
						Interfaces
							|
							Instancias
								|
								InstanciaUno
							|
							Kafka
							|
							Propiedades
							

# Documentation
Instancias : nombre del la base de datos que se va a consumir. CardHolder, Omnicanal, etc.

Kafka: Interface para envio de mensajes a Kafka.

Propiedades: Interface para consulta de propiedades API.


# Build 
IInstanciaUnoInfraestructura.cs: interface, infraestructura del servicio a invocar.

IInstanciaUnoRepositorio.cs: interface, repositorio del servicio a invocar.

IGenericoRepositorio.cs interfaces, del repositorio de Kafka.

IPropiedadesApi.cs interfaces, de la configuración de Propiedades Api.


# Nuget Packages
1. BP.Comun.Centralizada(1.0.2)
2. BP.Comun.Propiedades(1.0.0)
3. BP.Comun.Extensiones(1.0.0)
4. BP.Functional.Core(1.0.0)
5. BP.API.Constantes(1.0.0)
6. BP.Comun.Logs(2.0.0)
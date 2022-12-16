# Information
Implementacion de la infraestructura para llamar al repositorio.


	srbetancBBDDSQl.Repository						
						|
						Configuraciones
							|
							Api
							|
							Centralizada
							|
							Kafka
							|
							Persistencias
						|
						Instancias
							|
							InstanciaUno


# Documentation
Instancias : nombre del la base de datos que se va a consumir. CardHolder, Omnicanal, etc.

Configuraciones: Api, Kafka, Persistencias, configuraciones  predeterminadas de Centralizada (No se requiere de modificación)


# Build 
PropiedadesApi.cs: Configuración predeterminada de consulta de catálogos y configuraciones.

ConfiguradorCentralizada.cs: Configuración predeterminada de consultas a Centralizada.

ConfiguracionKafka.cs, RepositorioGenerico.cs: Configuración predeterminada para Generar mensajes en Kafka.

InstanciaUnoRepositorio.cs: Lógica del repositorio para hacer consultas con la base de datos. 

configmap.desa.json: Archivo de configuración de propiedades para Kafka

TopicoInicial: "T_" 

(Valor que identifica al tópico, este valor se toma del campo filler de la entrada).

TagsServersKafka": "SERVIDOR_KAFKA_01,SERVIDOR_KAFKA_02" 

(Servidor Kafka dónde se guardan los mensajes).   


TimeoutKafka": 10000 

(Tiempo de respuesta de Kafka).

# Nuget Packages
1.  BP.EventBus(1.0.2)
2.  EntityFramework(6.4.4)
3.  Microsoft.EntityFrameworkCore.Design(6.0.6)
4.  Microsoft.EntityFrameworkCore.SqlServer(6.0.6)
5.  Microsoft.EntityFrameworkCore.Tools(6.0.6)

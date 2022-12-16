# Information
Entidades: entradas y salida del servicio, DTO de servicios

	WSServicioBase.Entity					
						|
						Instancias
							|
							InstanciaUno
								|
								Entrada
								|
								Salida


# Documentation
Instancias : nombre del la base de datos que se va a consumir. CardHolder, Omnicanal, etc.


# Build 
Entrada.cs: Se definen las entradas del servicio a construir.

Salida.cs: Se definen las salidas del servicio a construir

Nota: Si existe más de un método debería ser agrupado por el nombre del método


# Nuget Packages
1. BP.API.Entidades(1.0.2)